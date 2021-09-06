using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class IssueConfig : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasOne(i => i.Newest)
                   .WithOne(e => e.IssueLast)
                   .HasForeignKey<Issue>(i => i.NewestId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(i => i.EventMessages)
                   .WithOne(e => e.Issue)
                   .HasForeignKey(e => e.IssueId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
