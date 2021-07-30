using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class DashboardConfig : IEntityTypeConfiguration<Dashboard>
    {
        public void Configure(EntityTypeBuilder<Dashboard> entity)
        {
            entity.Property(e => e.CreatedBy)
                  .IsRequired();

            entity.Property(e => e.CreatedAt)
                  .IsRequired();

            entity.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.HasMany(e => e.Tiles)
                  .WithOne(e => e.Dashboard)
                  .IsRequired(false);
        }
    }
}
