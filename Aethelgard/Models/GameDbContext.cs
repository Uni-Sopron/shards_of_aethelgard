using Microsoft.EntityFrameworkCore;

namespace Aethelgard.Models
{
    public class GameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=aethelgard_game.db");
        }
    }
}