using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(t => t.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.HasIndex(t => t.Name)
                   .IsUnique();

            builder.HasMany(t => t.TeamMembers)
                   .WithOne(tm => tm.Team)
                   .HasForeignKey(tm => tm.TeamId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(t => t.ApplicationTeams)
                   .WithOne(at => at.Team)
                   .HasForeignKey(at => at.TeamId)
                   .OnDelete(DeleteBehavior.ClientCascade);


            builder.Property(a => a.CreatedAt)
                .HasConversion(
                     v => v,
                     v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                     );
        }
    }
}
