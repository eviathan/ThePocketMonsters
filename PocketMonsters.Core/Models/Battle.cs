using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Battle
    {
        public List<Character> Allies { get; set; } = [];
        public List<Character> Enemies { get; set; } = [];

        public int Turn { get; set; }

        public void Attack(Character attacker, Character defender, MoveType moveType)
        {
            var attackingMonster = attacker.EquippedMonster;
            var defendingMonster = defender.EquippedMonster;
            var move = Move.Moves[moveType];

            var levelDamage = (2 * attackingMonster.Level * CalculateCritical() / 5) + 2;
            var attackAndDefense = CalculateAttackStat(attackingMonster.Stats, move.Category) / CalculateDefenseStat(defendingMonster.Stats, move.Category);
            var numerator = levelDamage * move.Power * attackAndDefense;
            var damage = ((numerator / 50) + 2) * CalculateSTAB(attackingMonster, move) * CalculateTypeEffectiveness(move, defendingMonster);

            damage = (int)(damage * Maths.RandomRange(0.85f, 1.0f));

            defender.EquippedMonster.Stats.Health -= (int)damage;
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

        private int CalculateCritical()
        {
            Random random = new Random();
        
            int minValue = 0;
            int maxValue = 255;
            
            int value = random.Next(minValue, maxValue);
            int threshhold = random.Next(minValue, maxValue);
            
            return value > threshhold ? 2 : 1;
        }

        private int CalculateAttackStat(MonsterStats stats, CategoryType categoryType)
        {
            switch (categoryType)
            {
                case CategoryType.Physical:
                    return stats.Attack;
                case CategoryType.Special:
                    return stats.SpecialAttack;
                default:
                    throw new ArgumentOutOfRangeException($"{categoryType} is not a supported Attack Stat!");
            }
        }

        private int CalculateDefenseStat(MonsterStats stats, CategoryType categoryType)
        {
            switch (categoryType)
            {
                case CategoryType.Physical:
                    return stats.Defense;
                case CategoryType.Special:
                    return stats.SpecialDefence;
                default:
                    throw new ArgumentOutOfRangeException($"{categoryType} is not a supported Defense Stat!");
            }
        }

        private float CalculateSTAB(Monster monster, Move move)
        {
            var beastiaryItem = Beastiary.Instance[monster.Type];
            var monsterElementTypes = beastiaryItem.Elements;
            
            var isMoveSameElementType = monsterElementTypes.Contains(move.Element);
            return isMoveSameElementType ? 1.5f : 1f;
        }

        private float CalculateTypeEffectiveness(Move move, Monster defender)
        {
            var aggregateEffectiveness = 1.0f;

            var beastiaryItem = Beastiary.Instance[defender.Type];

            foreach (var element in beastiaryItem.Elements)
            {
                var effectivness = ElementMatrix.Instance[move.Element, element];
                
                aggregateEffectiveness *= effectivness;
            }

            return aggregateEffectiveness;
        }
    }
}