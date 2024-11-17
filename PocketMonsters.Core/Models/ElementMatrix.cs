using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class ElementMatrix
    {
        private static readonly ElementMatrix _instance = new ElementMatrix();
        public static ElementMatrix Instance
        {
            get
            {
                return _instance;
            }
        }

        public float this[ElementType attacker, ElementType defender]
        {
            get
            {
                var output = _items[attacker][defender];
                return output;
            }                
            set => _items[attacker][defender] = value;
        }

        static ElementMatrix() { }

        private ElementMatrix() { }


        private Dictionary<ElementType, Dictionary<ElementType, float>> _items { get; set; } = new()
        {
            {
                ElementType.Fire, new ()
                {
                    { ElementType.Grass, 2.0f }
                }
            },
            {
                ElementType.Flying, new ()
                {
                    { ElementType.Grass, 2.0f }
                }
            },
            {
                ElementType.Grass, new()
                {
                    { ElementType.Fire, 0.5f },
                    { ElementType.Flying, 0.5f },
                }
            },
        };
    }
}