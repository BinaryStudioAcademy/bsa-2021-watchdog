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
            LoaderTests = new List<LoaderTest>();
        }
        public string OrganizationSlug { get; set; }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public User User { get; set; }

        public int DefaultRoleId { get; set; }

        public bool OpenMembership { get; set; }

        public bool TrelloIntegration { get; set; }
        public string TrelloBoard { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Application> Applications { get; set; }

        public ICollection<Dashboard> Dashboards { get; set; }

        public ICollection<LoaderTest> LoaderTests { get; set; }
    }
}
