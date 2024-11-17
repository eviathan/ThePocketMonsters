using System.Security.Cryptography.X509Certificates;
using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Extensions;
using PocketMonsters.Core.Service;

namespace PocketMonsters.Core.Models
{
    public class Battle
    {
        public List<Character> Allies { get; private set; } = [];
        public List<Character> Enemies { get; private set; } = [];
        public BattleState State { get; private set; }
        public Character CurrentCharacter => _interlleavedCharacters[_turn];

        private int _turn = 0;
        public int Turn 
        { 
            get => _turn;
            set => _turn = value % (Allies.Count + Enemies.Count);
        }

        private readonly List<Character> _interlleavedCharacters;
        private readonly Action<BattleState, BattleStats>? _onBattleDidEnd;

        public Battle(
            List<Character> allies,
            List<Character> enemies, 
            Action<BattleState, BattleStats>? onBattleDidEnd = null)
        {
            Allies = allies ?? throw new ArgumentNullException(nameof(allies));
            Enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            _onBattleDidEnd = onBattleDidEnd;

            _interlleavedCharacters = allies.InterleaveRandom(enemies);
        }

        public void Attack(Func<List<Character>, HashSet<MoveType>, AttackTurn> predicate)
        {
            var targetCharacters = Enemies;
            var attackTurnResult = predicate
            (
                targetCharacters,
                CurrentCharacter.EquippedMonster.MoveSet.Select(move => move.Type).ToHashSet()
            );

            attackTurnResult.Target.EquippedMonster.Stats.Health -= 
                DamageService.CalculateDamage(CurrentCharacter, attackTurnResult.Target, attackTurnResult.MoveType);

            EvaluateState();
        }

        public void UseItem(Character target, Item item)
        {
            throw new NotImplementedException("Not implemented yet!");
            // EvaluateState();
        }

        public void ChangeMonster(Func<List<MonsterType>, MonsterType> predicate)
        {
            var selectedMonsterType = predicate(
                CurrentCharacter.Monsters
                    .Select(monster => monster.Type)
                    .ToList()
            );

            CurrentCharacter.SwapMonster(selectedMonsterType);

            EvaluateState();
        }

        public void RunAway(Action<Character> onSuccess, Action<Character> onFailure)
        {
            var enemyMaxSpeed = Enemies
                .SelectMany(x => x.Monsters)
                .Select(x => x.Stats.Speed)
                .Order()
                .FirstOrDefault();

            var equippedMonsterSpeed = CurrentCharacter.EquippedMonster.Stats.Speed;

            var escapeChance = (equippedMonsterSpeed * 32 / enemyMaxSpeed) + 30;
            var escapeThreshold = Maths.RandomRange(0, 225);

            if(escapeChance > escapeThreshold)
            {
                State = BattleState.Escaped;
                onSuccess(CurrentCharacter);
            }
            else
            {
                onFailure(CurrentCharacter);
            }

            EvaluateState();
        }

        private void EvaluateState()
        {
            switch (State)
            {
                default:
                case BattleState.Active:
                    Turn++;
                    break;
                case BattleState.Won:
                case BattleState.Lost:
                case BattleState.Escaped:
                    _onBattleDidEnd?.Invoke(State, new BattleStats { });    
                    break;
            }
        }
    }
}