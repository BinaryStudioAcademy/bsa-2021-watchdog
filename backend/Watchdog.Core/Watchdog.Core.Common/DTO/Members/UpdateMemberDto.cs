using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Core.Common.DTO.Members
{
    public class UpdateMemberDto
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int TeamId { get; set; }
    }
}
