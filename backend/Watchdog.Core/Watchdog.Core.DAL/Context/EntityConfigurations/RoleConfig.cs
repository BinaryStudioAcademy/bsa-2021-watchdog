using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.Property(e => e.Description)
                  .HasMaxLength(512)
                  .IsRequired();

            entity.HasMany(r => r.Members)
                  .WithOne(m => m.Role);
        }
    }
}
