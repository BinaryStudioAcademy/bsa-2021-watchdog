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
            Issues = new List<Issue>();
            LoaderTests = new List<LoaderTest>();
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
        public ICollection<Tile> Tiles { get; set; }

        public ICollection<Environment> Environments { get; set; }

        public ICollection<ApplicationTeam> ApplicationTeams { get; set; }

        public ICollection<Issue> Issues { get; set; }

        public ICollection<LoaderTest> LoaderTests { get; set; }
    }
}
