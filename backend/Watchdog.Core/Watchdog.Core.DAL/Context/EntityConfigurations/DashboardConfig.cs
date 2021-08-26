using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class DashboardConfig : IEntityTypeConfiguration<Dashboard>
    {
        public void Configure(EntityTypeBuilder<Dashboard> builder)
        {
            builder.Property(d => d.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.HasMany(d => d.Tiles)
                   .WithOne(t => t.Dashboard)
                   .HasForeignKey(t => t.DashboardId);


            builder.Property(a => a.CreatedAt)
                .HasConversion(
                     v => v,
                     v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                     );
        }
    }
}
