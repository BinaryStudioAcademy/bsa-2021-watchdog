using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Core.Common.DTO.Members
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public int RoleId { get; set; }

        public  int OrganizationId { get; set; }

        public string Email { get; set; }

        public int TeamId { get; set; }
     
    }
}
