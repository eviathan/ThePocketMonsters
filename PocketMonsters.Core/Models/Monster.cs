using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Interfaces;

namespace PocketMonsters.Core.Models
{
    public class Monster
    {
        public string Name { get; set; }
        public MonsterType Type { get; set; }
        public byte Level { get; set; } = 1;
        public float Health { get; set; } = 100;
        public int PowerPoints { get; set; }
        public int ExperiencePoints { get; set; }

        public List<Modifier<Monster>> Modifiers { get; set; }
        public Dictionary<byte, MonsterType> Evolutions { get; set; } = [];
    }
}