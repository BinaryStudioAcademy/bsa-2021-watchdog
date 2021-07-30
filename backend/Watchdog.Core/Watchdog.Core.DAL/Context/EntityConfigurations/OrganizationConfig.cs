using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class OrganizationConfig : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(e => e.AvatarUrl)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.HasMany(o => o.Members)
                   .WithOne(m => m.Organization);

            builder.HasMany(e => e.Teams)
                   .WithOne(e => e.Organization)
                   .IsRequired(false);

            builder.HasMany(e => e.Applications)
                   .WithOne(e => e.Organization)
                   .IsRequired(false);

            builder.HasMany(e => e.Dashboards)
                   .WithOne(e => e.Organization);
        }
    }
}
