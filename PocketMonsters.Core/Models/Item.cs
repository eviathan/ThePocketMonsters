using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class Item
    {
        public ItemType Type { get; set; }
        public ItemCategory Category { get; set; }
        public Action<Monster> UseItem { get; set; }
    }
}