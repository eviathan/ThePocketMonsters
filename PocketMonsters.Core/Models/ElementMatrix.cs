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
                if(_items.ContainsKey(attacker) && _items[attacker].ContainsKey(defender))
                {
                    var output = _items[attacker][defender];
                    return output;
                }

                return 1.0f;
            }                
            set => _items[attacker][defender] = value;
        }

        static ElementMatrix() { }

        private ElementMatrix() { }


        private Dictionary<ElementType, Dictionary<ElementType, float>> _items { get; set; } = new()
        {
            {
                ElementType.Normal, new()
                {
                    { ElementType.Rock, 0.5f },
                    { ElementType.Ghost, 0f },
                    { ElementType.Steel, 0.5f }
                }
            },
            {
                ElementType.Fire, new()
                {
                    { ElementType.Grass, 2.0f },
                    { ElementType.Ice, 2.0f },
                    { ElementType.Bug, 2.0f },
                    { ElementType.Steel, 2.0f },
                    { ElementType.Fire, 0.5f },
                    { ElementType.Water, 0.5f },
                    { ElementType.Rock, 0.5f },
                    { ElementType.Dragon, 0.5f }
                }
            },
            {
                ElementType.Water, new()
                {
                    { ElementType.Fire, 2.0f },
                    { ElementType.Ground, 2.0f },
                    { ElementType.Rock, 2.0f },
                    { ElementType.Water, 0.5f },
                    { ElementType.Grass, 0.5f },
                    { ElementType.Dragon, 0.5f }
                }
            },
            {
                ElementType.Electric, new()
                {
                    { ElementType.Water, 2.0f },
                    { ElementType.Flying, 2.0f },
                    { ElementType.Electric, 0.5f },
                    { ElementType.Grass, 0.5f },
                    { ElementType.Dragon, 0.5f },
                    { ElementType.Ground, 0f }
                }
            },
            {
                ElementType.Grass, new()
                {
                    { ElementType.Water, 2.0f },
                    { ElementType.Ground, 2.0f },
                    { ElementType.Rock, 2.0f },
                    { ElementType.Fire, 0.5f },
                    { ElementType.Grass, 0.5f },
                    { ElementType.Poison, 0.5f },
                    { ElementType.Flying, 0.5f },
                    { ElementType.Bug, 0.5f },
                    { ElementType.Dragon, 0.5f },
                    { ElementType.Steel, 0.5f }
                }
            },
            {
                ElementType.Ice, new()
                {
                    { ElementType.Grass, 2.0f },
                    { ElementType.Ground, 2.0f },
                    { ElementType.Flying, 2.0f },
                    { ElementType.Dragon, 2.0f },
                    { ElementType.Fire, 0.5f },
                    { ElementType.Water, 0.5f },
                    { ElementType.Ice, 0.5f },
                    { ElementType.Steel, 0.5f }
                }
            },
            {
                ElementType.Fighting, new()
                {
                    { ElementType.Normal, 2.0f },
                    { ElementType.Ice, 2.0f },
                    { ElementType.Rock, 2.0f },
                    { ElementType.Dark, 2.0f },
                    { ElementType.Steel, 2.0f },
                    { ElementType.Poison, 0.5f },
                    { ElementType.Flying, 0.5f },
                    { ElementType.Psychic, 0.5f },
                    { ElementType.Bug, 0.5f },
                    { ElementType.Fairy, 0.5f },
                    { ElementType.Ghost, 0f }
                }
            },
            {
                ElementType.Flying, new()
                {
                    { ElementType.Grass, 2.0f },
                    { ElementType.Fighting, 2.0f },
                    { ElementType.Bug, 2.0f },
                    { ElementType.Electric, 0.5f },
                    { ElementType.Rock, 0.5f },
                    { ElementType.Steel, 0.5f }
                }
            },
            {
                ElementType.Poison, new()
                {
                    { ElementType.Grass, 2.0f },
                    { ElementType.Fairy, 2.0f },
                    { ElementType.Poison, 0.5f },
                    { ElementType.Ground, 0.5f },
                    { ElementType.Rock, 0.5f },
                    { ElementType.Ghost, 0.5f },
                    { ElementType.Steel, 0f }
                }
            },
            {
                ElementType.Ground, new()
                {
                    { ElementType.Fire, 2.0f },
                    { ElementType.Electric, 2.0f },
                    { ElementType.Poison, 2.0f },
                    { ElementType.Rock, 2.0f },
                    { ElementType.Steel, 2.0f },
                    { ElementType.Grass, 0.5f },
                    { ElementType.Bug, 0.5f },
                    { ElementType.Flying, 0f }
                }
            },
            {
                ElementType.Rock, new()
                {
                    { ElementType.Fire, 2.0f },
                    { ElementType.Ice, 2.0f },
                    { ElementType.Flying, 2.0f },
                    { ElementType.Bug, 2.0f },
                    { ElementType.Fighting, 0.5f },
                    { ElementType.Ground, 0.5f },
                    { ElementType.Steel, 0.5f }
                }
            },
            {
                ElementType.Bug, new()
                {
                    { ElementType.Grass, 2.0f },
                    { ElementType.Psychic, 2.0f },
                    { ElementType.Dark, 2.0f },
                    { ElementType.Fire, 0.5f },
                    { ElementType.Fighting, 0.5f },
                    { ElementType.Poison, 0.5f },
                    { ElementType.Flying, 0.5f },
                    { ElementType.Ghost, 0.5f },
                    { ElementType.Steel, 0.5f },
                    { ElementType.Fairy, 0.5f }
                }
            },
            {
                ElementType.Ghost, new()
                {
                    { ElementType.Ghost, 2.0f },
                    { ElementType.Psychic, 2.0f },
                    { ElementType.Dark, 0.5f },
                    { ElementType.Normal, 0f }
                }
            },
            {
                ElementType.Steel, new()
                {
                    { ElementType.Ice, 2.0f },
                    { ElementType.Rock, 2.0f },
                    { ElementType.Fairy, 2.0f },
                    { ElementType.Fire, 0.5f },
                    { ElementType.Water, 0.5f },
                    { ElementType.Electric, 0.5f },
                    { ElementType.Steel, 0.5f }
                }
            },
            {
                ElementType.Dragon, new()
                {
                    { ElementType.Dragon, 2.0f },
                    { ElementType.Steel, 0.5f },
                    { ElementType.Fairy, 0f }
                }
            },
            {
                ElementType.Dark, new()
                {
                    { ElementType.Psychic, 2.0f },
                    { ElementType.Ghost, 2.0f },
                    { ElementType.Fighting, 0.5f },
                    { ElementType.Dark, 0.5f },
                    { ElementType.Fairy, 0.5f }
                }
            },
            {
                ElementType.Fairy, new()
                {
                    { ElementType.Fighting, 2.0f },
                    { ElementType.Dragon, 2.0f },
                    { ElementType.Dark, 2.0f },
                    { ElementType.Fire, 0.5f },
                    { ElementType.Poison, 0.5f },
                    { ElementType.Steel, 0.5f }
                }
            }
        };
    }
}