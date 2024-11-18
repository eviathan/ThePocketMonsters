using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Satchel
    {
        private Dictionary<ItemType, int> _items { get; set; } = [];

        public HashSet<ItemType> GetAvaliableItemTypes()
        {
            return _items
                .Where(item => item.Value > 0)
                .Select(item => item.Key)
                .ToHashSet();
        }

        public bool TryUse(ItemType itemType, int amount = 1)
        {
            // TODO: Handle amount 
            if (_items.ContainsKey(itemType) && _items[itemType] > 0)
            {
                _items[itemType]--;
            }

            return false;
        }

        public bool TryAdd(ItemType itemType, int amount = 1)
        {
            if (!_items.ContainsKey(itemType))
            {
                _items[itemType] = amount;
                return true;
            }

            var currentAmount = _items[itemType];
            var amountOfSpaces = int.MaxValue - currentAmount;
            
            if(amountOfSpaces >= amount)
            {
                _items[itemType] += amount;
            }
            else 
            {
                for (int i = 0; i < amount; i++)
                {
                    _items[itemType] += amount;
                    
                    if(_items[itemType] == int.MaxValue)
                        return false;
                }
            }

            return true;
        }
    }
}