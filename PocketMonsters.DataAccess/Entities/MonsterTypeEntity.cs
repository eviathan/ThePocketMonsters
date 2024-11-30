using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PocketMonsters.Core.Enums;

namespace PocketMonsters.DataAccess.Entities
{
    public class MonsterTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ElementType> Elements { get; set; }
        public int EvolutionLevel { get; set; }

        public int? EvolutionTypeId { get; set; }
        public MonsterTypeEntity? EvolutionType { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TOOD: Probaly want to inject this
            var elementTypeConverter = new EnumCollectionToStringConverter<ElementType>();

            modelBuilder
                .Entity<MonsterTypeEntity>()
                .Property(monsterType => monsterType.Elements)
                .HasConversion(elementTypeConverter);
        }
    }
}