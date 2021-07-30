using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.Property(e => e.FirstName)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.Property(e => e.LastName)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.Property(e => e.Email)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.Property(e => e.PasswordHash)
                  .HasMaxLength(512)
                  .IsRequired();

            entity.Property(e => e.RegisteredAt)
                  .IsRequired();

            entity.Property(e => e.AvatarUrl)
                  .HasMaxLength(256)
                  .IsRequired();

            entity.HasMany(u => u.Members)
                  .WithOne(m => m.User)
                  .HasForeignKey(m => m.CreatedBy)
                  .IsRequired(false);

            entity.HasMany(u => u.Organizations)
                  .WithOne(o => o.User)
                  .HasForeignKey(o => o.CreatedBy);

            entity.HasMany(u => u.Teams)
                  .WithOne(t => t.User)
                  .HasForeignKey(t => t.CreatedBy);

            entity.HasMany(u => u.Applications)
                  .WithOne(a => a.User)
                  .HasForeignKey(a => a.CreatedBy);

            entity.HasMany(u => u.Dashboards)
                  .WithOne(d => d.User)
                  .HasForeignKey(d => d.CreatedBy)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(u => u.Tiles)
                  .WithOne(t => t.User)
                  .HasForeignKey(d => d.CreatedBy);
        }
    }
}
