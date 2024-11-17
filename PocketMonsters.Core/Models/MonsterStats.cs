namespace PocketMonsters.Core.Models
{
    public class MonsterStats
    {
        public int Health { get; set; } = 100;        
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefence { get; set; }
        public int Speed { get; set; }
    }
}