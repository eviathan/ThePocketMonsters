namespace PocketMonsters.DataAccess.Entities
{
    public class ItemEntity : BaseEntity
    {
        public Guid CharacterId { get; set; }
        public CharacterEntity Character { get; set; }
        public Guid ItemId { get; set; }
        public ItemTypeEntity Item { get; set; }
        public int Amount { get; set; }
    }
}