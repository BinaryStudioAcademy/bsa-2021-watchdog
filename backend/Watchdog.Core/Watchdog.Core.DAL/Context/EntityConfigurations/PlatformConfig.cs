using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class PlatformConfig : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.HasMany(p => p.Applications)
                   .WithOne(a => a.Platform)
                   .HasForeignKey(a => a.PlatformId);

            builder.HasMany(p => p.PlatformTypes)
                   .WithMany(pt => pt.Platforms)
                   .UsingEntity<PlatformsPlatformsType>(
                    r => r.HasOne<PlatformType>().WithMany().HasForeignKey(x => x.PlatformTypeId),
                    l => l.HasOne<Platform>().WithMany().HasForeignKey(x => x.PlatformId),
                    je =>
                    {
                        je.HasKey(x => new { x.PlatformId, x.PlatformTypeId});
                    });
        }
    }
}
