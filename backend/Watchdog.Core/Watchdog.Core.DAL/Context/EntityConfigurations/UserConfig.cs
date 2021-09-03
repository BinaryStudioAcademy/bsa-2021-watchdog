using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Uid)
                    .HasMaxLength(28)
                    .IsRequired();

            builder.Property(u => u.FirstName)
                   .HasMaxLength(128);

            builder.Property(u => u.LastName)
                   .HasMaxLength(128);

            builder.Property(u => u.Email)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.HasMany(u => u.CreatedMembers)
                   .WithOne(m => m.CreatedByUser)
                   .HasForeignKey(m => m.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Members)
                   .WithOne(m => m.User)
                   .HasForeignKey(m => m.UserId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(u => u.Organizations)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Teams)
                   .WithOne(t => t.User)
                   .HasForeignKey(t => t.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Applications)
                   .WithOne(a => a.User)
                   .HasForeignKey(a => a.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Dashboards)
                   .WithOne(d => d.User)
                   .HasForeignKey(d => d.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Tiles)
                   .WithOne(t => t.User)
                   .HasForeignKey(d => d.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);


            builder.Property(u => u.RegisteredAt)
                   .HasConversion(
                        v => v,
                        v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v
                        );
        }
    }
}
