using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();

            builder.Property(e => e.Description)
                  .HasMaxLength(512)
                  .IsRequired();

            builder.HasMany(r => r.Members)
                  .WithOne(m => m.Role);
        }
    }
}
