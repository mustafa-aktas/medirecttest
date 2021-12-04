using LightsOut_Api_Mustafa_Aktas.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightsOut_Api_Mustafa_Aktas.DataAccess.Configs
{
    public class GameSetupConfig : IEntityTypeConfiguration<GameSetup>
    {
        public void Configure(EntityTypeBuilder<GameSetup> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.HasMany(x => x.DefaultTiles).WithOne(y => y.GameSetup).HasForeignKey(t => t.GameSetupId);
        }
    }
}