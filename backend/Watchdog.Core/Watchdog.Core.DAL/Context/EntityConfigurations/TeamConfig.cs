using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.HasMany(t => t.Members)
                   .WithOne(m => m.Team)
                   .HasForeignKey(m => m.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
