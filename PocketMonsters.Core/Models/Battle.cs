using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Battle
    {
        public List<Character> Allies { get; set; } = [];
        public List<Character> Enemies { get; set; } = [];

        public int Turn { get; set; }

        public void Attack(Character source, Character target, MoveType moveType)
        {
            var move = Move.Moves[moveType];
            var levelDamage = (2 * source.EquippedMonster.Level * GetCritical() / 5) + 2;
            var numerator = levelDamage * move.Power * GetAttackStat(source, target);
            var damage = (numerator / 50) + 2;

            damage *= Maths.RandomRange(0.85f, 1.0f);

            target.EquippedMonster.Stats.Health -= damage;
        }

        public void UseItem(Character source, Character target, Item item)
        {
            // Try Get Item from character
            // Use Item on Target
        }

        public void SwapToMonster(Character character, MonsterType monsterType)
        {
            if (!character.TrySwapMonster(monsterType))
            {
                throw new ArgumentOutOfRangeException($"Character does not have a {monsterType} monster!");
            }
        }

        public void RunAway(Character character)
        {
            // TODO: Add run away logic
        }

        [Obsolete("Bullshit code!")]
        private float GetAttackStat(Character source, Character target)
        {
            var sourceBeastiaryItem = Beastiary.Instance[source.EquippedMonster.Type];
            var targetBeastiaryItem = Beastiary.Instance[target.EquippedMonster.Type];

            float attackMultiplier = 1.0f;
            float defenseMultiplier = 1.0f;
            
            foreach (var sourceElement in sourceBeastiaryItem.Elements)
            foreach (var targetElement in targetBeastiaryItem.Elements)
                attackMultiplier *= ElementMatrix.Instance[sourceElement, targetElement];

            foreach (var targetElement in targetBeastiaryItem.Elements)
            foreach (var sourceElement in sourceBeastiaryItem.Elements)
                defenseMultiplier *= ElementMatrix.Instance[targetElement, sourceElement];

            return attackMultiplier / defenseMultiplier;
        }

        private int GetCritical()
        {
            Random random = new Random();
        
            int minValue = 0;
            int maxValue = 255;
            
            int value = random.Next(minValue, maxValue);
            int threshhold = random.Next(minValue, maxValue);
            
            return value > threshhold ? 2 : 1;
        }
    }
}