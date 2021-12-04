using LightsOut_Api_Mustafa_Aktas.DataAccess.Configs;
using LightsOut_Api_Mustafa_Aktas.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LightsOut_Api_Mustafa_Aktas.DataAccess
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options)
        {
        }

        public DbSet<DefaultTile> DefaultTiles { get; set; }

        public DbSet<GameSetup> GameSetups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyConfigurations(modelBuilder);
        }

        private static void ApplyConfigurations(ModelBuilder modelBuilder) => modelBuilder
                .ApplyConfiguration(new GameSetupConfig())
                .ApplyConfiguration(new DefaultTileConfig());
    }
}