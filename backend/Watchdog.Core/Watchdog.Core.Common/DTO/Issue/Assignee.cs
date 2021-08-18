using System.Collections.Generic;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class Assignee
    {
        public ICollection<int> MemberIds { get; set; }
        public ICollection<int> TeamIds { get; set; }
    }
}
