using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Move
    {
        public MoveType Type { get; set; }
        public string Name => Type.ToString();
        public byte Power { get; set; }
        public byte Accuracy { get; set; }
        public byte Probability { get; set; }
        public int PowerPoints { get; set; }
        public ElementType Element { get; set; }
        public CategoryType Category { get; set; }
        public string Description { get; set; } = string.Empty;

        // TODO: Add context of the attack and call this afterwards
        public Action<Character, Character>? Effect { get; set; }
    }
}