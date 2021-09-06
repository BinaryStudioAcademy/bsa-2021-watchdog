using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class LoaderTestConfig : IEntityTypeConfiguration<LoaderTest>
    {
        public void Configure(EntityTypeBuilder<LoaderTest> builder)
        {
            builder.HasMany(t => t.Requests)
                   .WithOne(r => r.Test)
                   .HasForeignKey(r => r.TestId);

            builder.HasOne(t => t.Organization)
                   .WithMany(o => o.LoaderTests)
                   .HasForeignKey(t => t.OrganizationId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
