using System.Collections.Generic;

namespace Watchdog.Core.Common.Models.Issue
{
    public class Assignee
    {
        public ICollection<int> MemberIds { get; set; }
        public ICollection<int> TeamIds { get; set; }
    }
}
