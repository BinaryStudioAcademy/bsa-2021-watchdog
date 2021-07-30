using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class ApplicationConfig : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(a => a.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(a => a.SecurityToken)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.HasMany(a => a.Environments)
                   .WithOne(e => e.Application)
                   .HasForeignKey(e => e.ApplicationId);
        }
    }
}
