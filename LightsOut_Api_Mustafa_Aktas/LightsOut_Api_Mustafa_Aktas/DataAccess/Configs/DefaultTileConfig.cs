using LightsOut_Api_Mustafa_Aktas.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightsOut_Api_Mustafa_Aktas.DataAccess.Configs
{
    public class DefaultTileConfig : IEntityTypeConfiguration<DefaultTile>
    {
        public void Configure(EntityTypeBuilder<DefaultTile> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.HasOne(x => x.GameSetup).WithMany(y => y.DefaultTiles).HasForeignKey(f => f.GameSetupId);
        }
    }
}