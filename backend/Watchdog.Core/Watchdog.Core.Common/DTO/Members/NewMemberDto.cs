using System.Collections.Generic;

namespace Watchdog.Core.Common.DTO.Members
{
    public class NewMemberDto
    {
        public int RoleId { get; set; }

        public int CreatedBy { get; set; }

        public int OrganizationId { get; set; }

        public int UserId { get; set; }

        public IEnumerable<int> TeamIds { get; set; }
    }
}