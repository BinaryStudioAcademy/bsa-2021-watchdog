using System;
using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Member : AuditEntity<int>
    {
        public User User { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public Team Team { get; set; }

        public int TeamId { get; set; }

        public bool IsAccepted { get; set; } 

        public User CreatedByUser { get; set; }

    }
}
