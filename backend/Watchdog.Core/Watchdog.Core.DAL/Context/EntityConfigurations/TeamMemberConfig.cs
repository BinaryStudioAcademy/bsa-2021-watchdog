using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class TeamMemberConfig : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> entity)
        {
            entity.HasOne(tm => tm.Team)
                  .WithMany(t => t.TeamMembers)
                  .HasForeignKey(tm => tm.TeamId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(tm => tm.Member)
                  .WithMany(m => m.TeamMembers)
                  .HasForeignKey(tm => tm.MemberId);
        }
    }
}
