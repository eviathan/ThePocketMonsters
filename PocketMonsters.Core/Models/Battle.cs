using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Interfaces;

namespace PocketMonsters.Core.Models
{
    public class Battle
    {
        public List<Character> Allies { get; set; } = [];
        public List<Character> Enemies { get; set; } = [];

        public int Turn { get; set; }

        // Use Item
        // - Has Target
        // Attack
        // - Has Target
        // Use ability
        // - Has Target
        // Swap Monster
        // Waits/ Skip turn
        // Attempt to run away

        public void Attack(Character source, Character target, MoveType moveType)
        {
            // Basic Pokemon damage calculation logic:
            // damage = ((2 * level / 5) + 2) * movePower * (attackStat/ defenseStat) * modifier
            // Calculate Damage
            var move = Move.Moves[moveType];
            var damage = ((2 * source.EquippedMonster.Level / 5) + 2) * move.Power * GetAttackStat(source, target);

            target.EquippedMonster.Health -= damage;
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
    }
}