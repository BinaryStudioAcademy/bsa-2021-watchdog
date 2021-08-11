using System;

namespace Watchdog.Core.Common.Models.Issue
{
    public class IssueMessage
    {
        public DateTime OccurredOn { get; set; }
        
        public IssueMessageDetails IssueDetails { get; set; }
    }
}