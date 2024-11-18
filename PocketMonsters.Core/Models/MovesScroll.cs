using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class MoveScroll
    {
        public static MoveScroll Instance = new();
        
        private MoveScroll() { }
        static MoveScroll() { }

        public Move this[MoveType type]
        {
            get => _items.ContainsKey(type) ? _items[type] : null;
            set => _items[type] = value;
        }

        private Dictionary<MoveType, Move> _items { get; } = new Dictionary<MoveType, Move>
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
            {
                MoveType.TheOldDickTwist,
                new Move
                {
                    Type = MoveType.TheOldDickTwist,
                    Element = ElementType.Normal,
                    Category = CategoryType.Physical,
                    Power = 255,
                    Accuracy = 255,
                    PowerPoints = 15,
                    Description = "Break your emeies balls with this move!",
                }
            },
        };
    }
}