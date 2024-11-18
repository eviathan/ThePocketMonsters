using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Catalog
    {
        public static Catalog Instance = new();
        private Catalog() { }
        static Catalog() { }

        public Item this[ItemType type]
        {
            get => _items.ContainsKey(type) ? _items[type] : null;
            set => _items[type] = value;
        }

        private Dictionary<ItemType, Item> _items { get; set; } = new()
        {
            [ItemType.Potion] = new Item
            {
                Type = ItemType.Potion,
                UseItem = (monster) =>
                {
                    monster.Stats.Health += 20;
                }
            },
            [ItemType.RareCandy] = new Item
            {
                Type = ItemType.RareCandy,
                UseItem = (monster) =>
                {
                    monster.Level++;
                }
            },
            [ItemType.BookTheOldDickTwist] = new Item
            {
                Type = ItemType.BookTheOldDickTwist,
                UseItem = (monster) =>
                {
                    monster.MoveSet.Add(MoveType.TheOldDickTwist);
                }
            },
        };
    }
}