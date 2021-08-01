using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class TeamMemberConfig : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasOne(tm => tm.Team)
                   .WithMany(t => t.TeamMembers)
                   .HasForeignKey(tm => tm.TeamId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(tm => tm.Member)
                   .WithMany(m => m.TeamMembers)
                   .HasForeignKey(tm => tm.MemberId);
        }
    }
}
