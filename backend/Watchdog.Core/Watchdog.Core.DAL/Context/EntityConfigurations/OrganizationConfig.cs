using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class OrganizationConfig : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(o => o.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(o => o.OrganizationSlug)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(o => o.OpenMembership)
                    .IsRequired();

            builder.Property(o => o.AvatarUrl)
                   .HasMaxLength(256);

            builder.HasMany(o => o.Members)
                   .WithOne(m => m.Organization)
                   .HasForeignKey(m => m.OrganizationId);

            builder.HasMany(o => o.Teams)
                   .WithOne(t => t.Organization)
                   .HasForeignKey(t => t.OrganizationId);

            builder.HasMany(o => o.Applications)
                   .WithOne(a => a.Organization)
                   .HasForeignKey(a => a.OrganizationId);

            builder.HasMany(o => o.Dashboards)
                   .WithOne(d => d.Organization)
                   .HasForeignKey(d => d.OrganizationId);
        }
    }
}
