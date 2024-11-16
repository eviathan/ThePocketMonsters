using PocketMonsters.Core.Interfaces;

namespace PocketMonsters.Core.Models
{
    public abstract class Character
    {
        public string Name { get; protected set; }

        public List<IItem> Items { get; set; } = [];
        public List<Monster> Monsters { get; set; } = [];
    }
}