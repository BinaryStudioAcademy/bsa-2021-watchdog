using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class TileConfig : IEntityTypeConfiguration<Tile>
    {
        public void Configure(EntityTypeBuilder<Tile> builder)
        {
            builder.Property(t => t.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(t => t.TileOrder)
                .HasDefaultValue(1)
                .IsRequired();
            
            builder.Property(a => a.CreatedAt)
                .HasConversion(
                     v => v,
                     v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                     );

        }
    }
}
