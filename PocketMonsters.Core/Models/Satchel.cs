using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Satchel
    {
        private Dictionary<ItemType, int> _items { get; set; } = [];

        private Dictionary<ItemType, Item> _itemMap { get; set; } = new()
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
        };

        public bool TryUse(ItemType itemType, out Item item)
        {
            item = null;

            if (_items.ContainsKey(itemType) && _items[itemType] > 0)
            {
                item = _itemMap[itemType];
                _items[itemType]--;
            }

            return false;
        }
    }
}