using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Watchdog.Core.DAL.Entities;
using Watchdog.Core.DAL.Entities.AlertSettings;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class AssigneeMemberConfig : IEntityTypeConfiguration<AssigneeMember>
    {
        public void Configure(EntityTypeBuilder<AssigneeMember> builder)
        {
            builder.Property(a => a.IssueId)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.HasOne(a => a.Member)
                   .WithMany(m => m.AssigneeMembers)
                   .HasForeignKey(a => a.MemberId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
