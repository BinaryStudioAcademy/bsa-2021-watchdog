using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class TileConfig : IEntityTypeConfiguration<Tile>
    {
        public void Configure(EntityTypeBuilder<Tile> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(128)
                   .IsRequired();
        }
    }
}
