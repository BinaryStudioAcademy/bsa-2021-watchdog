using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class AssigneeTeamConfig : IEntityTypeConfiguration<AssigneeTeam>
    {
        public void Configure(EntityTypeBuilder<AssigneeTeam> builder)
        {
            builder.Property(a => a.IssueId)
                .IsRequired();

            builder.HasOne(a => a.Team)
                   .WithMany(t => t.AssigneeTeams)
                   .HasForeignKey(a => a.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
