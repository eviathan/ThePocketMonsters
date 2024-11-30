namespace PocketMonsters.DataAccess.Entities
{
    public class CharacterEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public List<MonsterEntity> Monsters { get; set; }
        public List<ItemEntity> Items { get; set; }
    }
}