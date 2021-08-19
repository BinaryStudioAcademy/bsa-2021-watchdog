using System.Collections.Generic;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class AssigneeDto
    {
        public ICollection<int> MemberIds { get; set; }
        public ICollection<int> TeamIds { get; set; }
    }
}