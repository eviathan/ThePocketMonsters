using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocketMonsters.Core.Enums;

namespace PocketMonsters.DataAccess.Entities
{
    public class MoveEntity : BaseEntity
    {
        public string Name => Type.ToString();
        public string Description { get; set; }
        public MoveType Type { get; set; }
        public CategoryType Category { get; set; }
        public byte Power { get; set; }
        public byte Accuracy { get; set; }
        public byte Probability { get; set; }
        public int PowerPoints { get; set; }

        public ElementType Element { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<MoveEntity>()
                .Property(move => move.Type)
                .HasConversion(new EnumToStringConverter<MoveType>());
        }
    }
}