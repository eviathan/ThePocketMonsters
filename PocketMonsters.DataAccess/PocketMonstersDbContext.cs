using Microsoft.EntityFrameworkCore;
using PocketMonsters.DataAccess.Entities;

namespace PocketMonsters.DataAccess
{
    public class PocketMonstersDbContext : DbContext
    {
        public DbSet<CharacterEntity> Characters { get; set; }
        public DbSet<ItemTypeEntity> CharacterItems { get; set; }
        public DbSet<ItemTypeEntity> Items { get; set; }
        public DbSet<MonsterEntity> Monsters { get; set; }
        public DbSet<MonsterMoveEntity> MonsterMoves { get; set; }
        public DbSet<MonsterTypeEntity> MonsterTypes { get; set; }
        public DbSet<MoveEntity> Moves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../database.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MonsterTypeEntity.OnModelCreating(modelBuilder);
            MoveEntity.OnModelCreating(modelBuilder);
        }
    }
}