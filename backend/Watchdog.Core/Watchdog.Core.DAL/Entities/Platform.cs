using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Platform : Entity<int>
    {
        public Platform()
        {
            Applications = new List<Application>();
        }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public PlatformTypes PlatformTypes { get; set; }

        public ICollection<Application> Applications { get; set; }
        
    }
}
