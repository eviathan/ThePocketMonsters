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

        public static Dictionary<MoveType, Move> Moves { get; } = new Dictionary<MoveType, Move>
        {
            {
                MoveType.FagBurn,
                new Move
                {
                    Type = MoveType.FagBurn,
                    Element = ElementType.Fire,
                    Category = CategoryType.Special,
                    Power = 90,
                    Accuracy = 100,
                    PowerPoints = 10,
                    Description = "Puts cigerette out on opponent and recovers half the HP inflicted on them.",
                    Effect = (source, target) => {
                        // TODO: Do Effect in here
                    }
                }
            },
            {
                MoveType.WoodHammer,
                new Move
                {
                    Type = MoveType.WoodHammer,
                    Element = ElementType.Grass,
                    Category = CategoryType.Physical,
                    Power = 120,
                    Accuracy = 100,
                    PowerPoints = 15,
                    Description = "Use your morning wood to hammer your opponents booty!",
                }
            },
        };
    }
}