using System.Collections.Generic;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.Common.DTO.Team
{
    public class TeamDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<MemberDto> Members { get; set; }
    }
}