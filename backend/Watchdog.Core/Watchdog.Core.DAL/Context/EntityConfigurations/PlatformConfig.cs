using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.Property(p => p.AvatarUrl)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.HasMany(p => p.Applications)
                   .WithOne(a => a.Platform)
                   .HasForeignKey(a => a.PlatformId);
        }
    }
}
