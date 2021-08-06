using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Application : AuditEntity<int>
    {
        public Application()
        {
            Environments = new List<Environment>();
            ApplicationTeams = new List<ApplicationTeam>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SecurityToken { get; set; }

        public User User { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }

        public ICollection<Environment> Environments { get; set; }

        public ICollection<ApplicationTeam> ApplicationTeams { get; set; }
    }
}
