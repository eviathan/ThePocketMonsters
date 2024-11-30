using PocketMonsters.Core.Enums;

namespace PocketMonsters.DataAccess.Entities
{
    public class ItemTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public ItemCategory Category { get; set; }
    }
}