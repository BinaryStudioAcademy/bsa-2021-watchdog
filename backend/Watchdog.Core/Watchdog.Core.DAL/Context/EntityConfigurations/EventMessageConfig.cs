using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using Watchdog.Core.DAL.Entities;
using Watchdog.Core.DAL.Entities.AlertSettings;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class EventMessageConfig : IEntityTypeConfiguration<EventMessage>
    {
        public void Configure(EntityTypeBuilder<EventMessage> builder)
        {

            builder.Property(a => a.OccurredOn)
                   .HasConversion(
                        v => v,
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                        );
        }
    }
}
