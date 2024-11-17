
using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class AttackTurn
    {
        public MoveType MoveType { get; set; }
        public Character Target { get; set; }
    }
}