using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class DashboardConfig : IEntityTypeConfiguration<Dashboard>
    {
        public void Configure(EntityTypeBuilder<Dashboard> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.HasMany(e => e.Tiles)
                   .WithOne(e => e.Dashboard)
                   .IsRequired(false);
        }
    }
}
