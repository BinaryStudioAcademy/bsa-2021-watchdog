using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class ApplicationConfig : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(e => e.CreatedBy)
                  .IsRequired();

            builder.Property(e => e.CreatedAt)
                  .IsRequired();

            builder.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();

            builder.Property(e => e.SecurityToken)
                  .HasMaxLength(256)
                  .IsRequired();

            builder.HasMany(e => e.Environments)
                  .WithOne(e => e.Application)
                  .IsRequired(false);
        }
    }
}
