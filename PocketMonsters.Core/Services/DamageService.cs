using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Models;

namespace PocketMonsters.Core.Service
{
    public static class DamageService
    {
        public static int CalculateDamage(Character attacker, Character defender, MoveType moveType)
        {
            var attackingMonster = attacker.EquippedMonster;
            var defendingMonster = defender.EquippedMonster;
            var move = MoveScroll.Instance[moveType];

            ApplyModifiers(attackingMonster);
            ApplyModifiers(defendingMonster);

            var levelDamage = (2 * attackingMonster.Level * CalculateCritical() / 5) + 2;
            var attackAndDefense = CalculateAttackStat(attackingMonster.Stats, move.Category) / CalculateDefenseStat(defendingMonster.Stats, move.Category);
            var numerator = levelDamage * move.Power * attackAndDefense;
            var damage = ((numerator / 50) + 2) * CalculateSTAB(attackingMonster, move) * CalculateTypeEffectiveness(move, defendingMonster);

            damage = (int)(damage * Maths.RandomRange(0.85f, 1.0f));

            return (int)damage;
        }

        private static void ApplyModifiers(Monster monster)
        {
            var predicate = (Monster monster) => 
            {

            };

            foreach (var modifier in monster.Modifiers)
            {
                if(modifier.TryModify(monster, predicate))
                {
                    // TODO: DO THE THING HERE
                }
            }
        }

        private static int CalculateCritical()
        {
            Random random = new Random();
        
            int minValue = 0;
            int maxValue = 255;
            
            int value = random.Next(minValue, maxValue);
            int threshhold = random.Next(minValue, maxValue);
            
            return value > threshhold ? 2 : 1;
        }

        private static int CalculateAttackStat(MonsterStats stats, CategoryType categoryType)
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

        private static int CalculateDefenseStat(MonsterStats stats, CategoryType categoryType)
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

        private static float CalculateSTAB(Monster monster, Move move)
        {
            var beastiaryItem = Beastiary.Instance[monster.Type];
            var monsterElementTypes = beastiaryItem.Elements;
            
            var isMoveSameElementType = monsterElementTypes.Contains(move.Element);
            return isMoveSameElementType ? 1.5f : 1f;
        }

        private static float CalculateTypeEffectiveness(Move move, Monster defender)
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