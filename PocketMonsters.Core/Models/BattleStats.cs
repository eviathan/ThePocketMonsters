
namespace PocketMonsters.Core.Models
{
    // TODO: Log each turn and the state of play for recall later
    public class BattleStats
    {
        public List<Character> Winners { get; set; }
        public List<Character> Losers { get; set; }
        public int ExperiencePoints { get; set; }
        public int Money { get; set; }
        public int Items { get; set; }
        public int Monsters { get; set; }
    }
}