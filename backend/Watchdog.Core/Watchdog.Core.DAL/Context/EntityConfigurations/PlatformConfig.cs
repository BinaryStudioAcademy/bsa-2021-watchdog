using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class PlatformConfig : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> entity)
        {
            entity.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.Property(e => e.AvatarUrl)
                  .HasMaxLength(256)
                  .IsRequired();

            entity.HasMany(e => e.Applications)
                  .WithOne(e => e.Platform);
        }
    }
}
