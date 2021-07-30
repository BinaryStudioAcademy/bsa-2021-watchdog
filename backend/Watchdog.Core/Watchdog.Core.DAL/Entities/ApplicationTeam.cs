using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class ApplicationTeam : Entity<int>
    {
        public int ApplicationId { get; set; }

        public Application Application { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
