using System.Collections.Generic;
using Watchdog.Core.Common.DTO.Role;
using Watchdog.Core.Common.DTO.Team;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.DTO.Members
{
    public class MemberDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
        public  int OrganizationId { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<TeamOptionDto> Teams { get; set; }
        public bool IsAccepted { get; set; }
    }
}
