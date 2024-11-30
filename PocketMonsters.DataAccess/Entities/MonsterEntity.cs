namespace PocketMonsters.DataAccess.Entities
{
    public class MonsterEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; } = 100;        
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefence { get; set; }
        public int Speed { get; set; }

        public List<MonsterMoveEntity> MonsterMoves { get; set; }

        public int MonsterTypeId { get; set; }
        public MonsterTypeEntity MonsterType { get; set; }

        public int CharacterId { get; set; }
        public CharacterEntity Character { get; set; }
    }
}