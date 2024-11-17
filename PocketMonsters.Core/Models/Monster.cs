using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Monster
    {
        public string Name { get; private set; }
        public MonsterType Type { get; private set; }
        public byte Level { get; set; }
        public int ExperiencePoints { get; private set; }
        public MonsterStats Stats { get; private set; }
        public List<Move> MoveSet { get; private set; }
        public List<Modifier<Monster>> Modifiers { get; private set; }
        
        public Monster(string name, MonsterType type, byte level = 1, MonsterStats? stats = null, List<Move> moveSet = null, List<Modifier<Monster>> modifiers = null)
        {
            Name = name;
            Type = type;
            Level = level;
            Stats = stats ?? Beastiary.Instance[Type].BaseStats;
            MoveSet = moveSet ?? Beastiary.Instance[Type].BaseMoveSet;
            Modifiers = modifiers ?? [];
        }
    }
}