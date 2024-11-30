using Microsoft.EntityFrameworkCore;
using PocketMonsters.DataAccess;

namespace PocketMonsters.Core.App
{
    public class Game
    {
        public Game()
        {
            InitDatabase();
        }

        public void InitDatabase()
        {
            using var dbContext = new PocketMonstersDbContext();
            dbContext.Database.EnsureCreated();

            if (!dbContext.Moves.Any())
            {
                dbContext.Moves
                    .AddRange(Defaults.Moves);
            }

            if (!dbContext.MonsterTypes.Any())
            {
                dbContext.MonsterTypes
                    .AddRange(Defaults.MonsterTypes);
            }


            dbContext.SaveChanges();

            Console.WriteLine("Application has started. Press any key to exit...");
            Console.ReadKey();
        }
    }
}