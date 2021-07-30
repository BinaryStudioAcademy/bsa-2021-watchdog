﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context.EntityConfigurations
{
    public class ApplicationConfig : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> entity)
        {
            entity.Property(e => e.CreatedBy)
                  .IsRequired();

            entity.Property(e => e.CreatedAt)
                  .IsRequired();

            entity.Property(e => e.Name)
                  .HasMaxLength(128)
                  .IsRequired();

            entity.Property(e => e.SecurityToken)
                  .HasMaxLength(256)
                  .IsRequired();

            entity.HasMany(e => e.Environments)
                  .WithOne(e => e.Application)
                  .IsRequired(false);
        }
    }
}
