using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Interfaces
{
    public interface ICombatable
    {
        HashSet<MonsterType> Types { get; set; }
        byte Level { get; set; }
    }
}