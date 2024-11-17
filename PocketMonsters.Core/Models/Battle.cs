using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Extensions;

namespace PocketMonsters.Core.Models
{
    public class AttackTurn
    {
        public MoveType MoveType { get; set; }
        public Character Target { get; set; }
    }

    public class Battle
    {
        public List<Character> Allies { get; private set; } = [];
        public List<Character> Enemies { get; private set; } = [];

        public Character CurrentCharacter => _interlleavedCharacters[_turn];

        private int _turn = 0;
        public int Turn 
        { 
            get => _turn;
            set => _turn = value % (Allies.Count + Enemies.Count);
        }

        private readonly List<Character> _interlleavedCharacters;

        public Battle(List<Character> allies, List<Character> enemies)
        {
            Allies = allies ?? throw new ArgumentNullException(nameof(allies));
            Enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));

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

            Turn++;
        }

        public void UseItem(Character target, Item item)
        {
            // Try Get Item from character
            // Use Item on Target

            Turn++;
        }

        public void ChangeMonster()
        {
            Turn++;
        }

        public void RunAway()
        {
            // TODO: Add run away logic

            Turn++;
        }
    }
}