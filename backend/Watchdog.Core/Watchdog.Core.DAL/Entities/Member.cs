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
            AssigneeMembers = new List<AssigneeMember>();
        }
        public User User { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }

        public ICollection<AssigneeMember> AssigneeMembers { get; set; }

        public bool IsAccepted { get; set; } 

        public User CreatedByUser { get; set; }

    }
}
