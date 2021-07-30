using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class EnvironmentConfig : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> entity)
        {
            entity.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();
        }
    }
}
