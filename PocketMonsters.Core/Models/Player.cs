namespace PocketMonsters.Core.Models
{
    public class Player : Character
    {
        public Player(string name)
        {
            Name = name;
        }

        public int Money { get; set; } = 3000;
    }
}