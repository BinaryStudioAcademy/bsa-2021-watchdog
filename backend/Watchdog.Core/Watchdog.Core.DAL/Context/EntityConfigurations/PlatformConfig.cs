using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class PlatformConfig : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(e => e.AvatarUrl)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.HasMany(e => e.Applications)
                   .WithOne(e => e.Platform);
        }
    }
}
