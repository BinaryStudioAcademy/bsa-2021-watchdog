using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class OrganizationConfig : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> entity)
        {
            entity.Property(e => e.CreatedBy)
                  .IsRequired();

            entity.Property(e => e.CreatedAt)
                  .IsRequired();

            entity.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.Property(e => e.AvatarUrl)
                  .HasMaxLength(256)
                  .IsRequired();

            entity.HasMany(o => o.Members)
                  .WithOne(m => m.Organization);

            entity.HasMany(e => e.Teams)
                  .WithOne(e => e.Organization)
                  .IsRequired(false);

            entity.HasMany(e => e.Applications)
                  .WithOne(e => e.Organization)
                  .IsRequired(false);

            entity.HasMany(e => e.Dashboards)
                  .WithOne(e => e.Organization);
        }
    }
}
