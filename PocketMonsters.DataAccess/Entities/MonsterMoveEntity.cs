namespace PocketMonsters.DataAccess.Entities
{
    public class MonsterMoveEntity : BaseEntity
    {
        public MonsterEntity Monster { get; set; }

        public MoveEntity Move { get; set; }
    }
}