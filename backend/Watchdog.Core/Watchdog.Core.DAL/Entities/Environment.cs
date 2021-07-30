using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Environment : Entity<int>
    {
        public string Name { get; set; }

        public int? ApplicationId { get; set; }

        public Application Application { get; set; }
    }
}
