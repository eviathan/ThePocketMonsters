using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Interfaces;

namespace PocketMonsters.Core.Models
{
    public class Monster
    {
        public string Name { get; set; }
        public MonsterType Type { get; set; }
        public byte Level { get; set; }
        public int ExperiencePoints { get; set; }


        public Dictionary<byte, MonsterType> Evolutions { get; set; } = [];
    }
}