using System;
using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Member : AuditEntity<int>
    {

        public Member()
        {
            TeamMembers = new List<TeamMember>();
        }
        public User User { get; set; }

        public string UserFirstName => User.FirstName;

        public string UserEmail => User.Email;

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string RoleName => Role.Name;

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }

        public bool IsAccepted { get; set; } 

        public User CreatedByUser { get; set; }

    }
}
