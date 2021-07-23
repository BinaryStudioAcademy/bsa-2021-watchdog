using Microsoft.EntityFrameworkCore;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context
{
    public class WatchdogCoreContext : DbContext
    {
        public DbSet<Sample> Samples { get; private set; }

        public WatchdogCoreContext(DbContextOptions<WatchdogCoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            modelBuilder.Seed();
        }
    }
}
