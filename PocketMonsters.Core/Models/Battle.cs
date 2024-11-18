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

        public Battle(List<Character> allies, List<Character> enemies, Action<BattleState, BattleStats>? onBattleDidEnd = null)
        {
            Allies = allies ?? throw new ArgumentNullException(nameof(allies));
            Enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            _interlleavedCharacters = allies.InterleaveRandom(enemies);
            _onBattleDidEnd = onBattleDidEnd;
        }

        public void Attack(Func<List<Character>, HashSet<MoveType>, AttackTurn> predicate)
        {
            var targetIsEnemies = Allies.Contains(CurrentCharacter); 
            var targetCharacters = targetIsEnemies ? Enemies : Allies;

            var attackTurnResult = predicate
            (
                targetCharacters,
                CurrentCharacter.EquippedMonster.MoveSet.Select(move => move.Type).ToHashSet()
            );

            attackTurnResult.Target.EquippedMonster.Stats.Health -= 
                DamageService.CalculateDamage(CurrentCharacter, attackTurnResult.Target, attackTurnResult.MoveType);

            EvaluateState();
        }

        public void UseItem(Character target, Func<IEnumerable<ItemType>, ItemType> predicate)
        {
            var itemType = predicate(CurrentCharacter.Satchel.GetAvaliableItemTypes() ?? []);
            var item = Catalog.Instance[itemType];
            item.UseItem(target.EquippedMonster);
            
            EvaluateState();
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
            var enemiesSurvived = CheckIfSurvived(Enemies);
            var alliesSurvived = CheckIfSurvived(Allies);

            List<Character> winners = [];

            if(!enemiesSurvived)
            {
                winners = Allies;
                State = BattleState.Won;
            }
            else if(!alliesSurvived)
            {
                winners = Enemies;
                State = BattleState.Lost;
            }
            else if (!enemiesSurvived && !alliesSurvived)
            {
                winners = Allies.Concat(Enemies).ToList();
                State = BattleState.Draw;
            }

            switch (State)
            {
                default:
                case BattleState.Active:
                    Turn++;
                    break;
                case BattleState.Won:
                case BattleState.Lost:
                case BattleState.Draw:
                case BattleState.Escaped:
                    _onBattleDidEnd?.Invoke(State, new BattleStats 
                    { 
                        Winners = winners
                    });    
                    break;
            }
        }

        private bool CheckIfSurvived(IEnumerable<Character> characters)
        {
            return characters
                .SelectMany(character => character.Monsters)
                .Any(monster => monster.Stats.Health > 0);
        }
    }
}