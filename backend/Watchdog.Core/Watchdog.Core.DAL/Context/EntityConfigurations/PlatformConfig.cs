using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

            var converter = new EnumToNumberConverter<PlatformTypes, int>();
            builder.Property(p => p.PlatformTypes)
                   .HasConversion(converter);

            builder.HasMany(p => p.Applications)
                   .WithOne(a => a.Platform)
                   .HasForeignKey(a => a.PlatformId);

            
        }
    }
}
