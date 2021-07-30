using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class ApplicationTeamConfig : IEntityTypeConfiguration<ApplicationTeam>
    {
        public void Configure(EntityTypeBuilder<ApplicationTeam> entity)
        {
            entity.HasOne(at => at.Application)
                  .WithMany(a => a.ApplicationTeams)
                  .HasForeignKey(at => at.ApplicationId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(at => at.Team)
                  .WithMany(t => t.ApplicationTeams)
                  .HasForeignKey(at => at.TeamId);
        }
    }
}
