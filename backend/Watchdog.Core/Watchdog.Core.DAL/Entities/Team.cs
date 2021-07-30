using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Team : AuditEntity<int>
    {
        public string Name { get; set; }

        public User User { get; set; }

        public int? OrganizationId { get; set; }
        
        public Organization Organization { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }

        public ICollection<ApplicationTeam> ApplicationTeams { get; set; }
    }
}
