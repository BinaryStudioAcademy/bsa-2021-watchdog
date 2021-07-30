using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Member : AuditEntity<int>
    {
        public User User { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }
    }
}
