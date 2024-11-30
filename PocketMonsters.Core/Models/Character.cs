using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Models;

namespace PocketMonsters.Core.Models
{
    public abstract class Character
    {
        public string Name { get; protected set; }

        public Monster EquippedMonster { get; set; }

        public List<Monster> Monsters { get; set; } = [];

        public Satchel Satchel { get; set; }

        public Character()
        {
            Satchel = new(this);    
        }
 
        public bool TrySwapMonster(MonsterType monsterType)
        {
            var monster = Monsters.FirstOrDefault(m => m.Type == monsterType);
            if (monster != null)
            {
                EquippedMonster = monster;
                return true;
            }

            return false;
        }

        public void SwapMonster(MonsterType monsterType)
        {
            if (!TrySwapMonster(monsterType))
            {
                throw new ArgumentOutOfRangeException($"Character does not have a {monsterType} monster!");
            }
        }
    }
}