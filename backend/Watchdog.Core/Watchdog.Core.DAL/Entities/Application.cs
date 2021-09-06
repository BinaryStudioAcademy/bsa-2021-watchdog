using System;
using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.AlertSettings;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Application : AuditEntity<int>
    {
        public Application()
        {
            Environments = new List<Environment>();
            ApplicationTeams = new List<ApplicationTeam>();
            Recipients = new List<User>();
            Issues = new List<Issue>();
            ApiKey = Guid.NewGuid().ToString();
        }

        public string ApiKey { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User User { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }

        public AlertSetting AlertSettings { get; set; }
        
        public ICollection<User> Recipients { get; set; }

        public ICollection<Environment> Environments { get; set; }

        public ICollection<ApplicationTeam> ApplicationTeams { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
