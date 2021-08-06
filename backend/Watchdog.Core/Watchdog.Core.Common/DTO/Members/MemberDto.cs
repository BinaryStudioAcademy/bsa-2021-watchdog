using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public TeamDto Team { get; set; }
        public int TeamId { get; set; }
    }
}
