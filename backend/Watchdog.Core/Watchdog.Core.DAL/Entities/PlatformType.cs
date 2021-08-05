using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class PlatformType : Entity<int>
    {
        public PlatformType()
        {
            Platforms = new List<Platform>();
        }
        public string Name { get; set; }

        public ICollection<Platform> Platforms { get; set; }
    }
}
