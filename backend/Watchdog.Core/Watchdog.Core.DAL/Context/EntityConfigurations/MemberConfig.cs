using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.HasMany(m => m.TeamMembers)
                   .WithOne(tm => tm.Member)
                   .HasForeignKey(tm => tm.MemberId)
                   .OnDelete(DeleteBehavior.ClientCascade);


            builder.Property(a => a.CreatedAt)
                .HasConversion(
                     v => v,
                     v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                     );
        }
    }
}
