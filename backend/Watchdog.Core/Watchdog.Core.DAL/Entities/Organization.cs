using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Organization : AuditEntity<int>
    {
        public Organization()
        {
            Members = new List<Member>();
            Teams = new List<Team>();
            Applications = new List<Application>();
            Dashboards = new List<Dashboard>();
        }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public User User { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Application> Applications { get; set; }

        public ICollection<Dashboard> Dashboards { get; set; }
    }
}
