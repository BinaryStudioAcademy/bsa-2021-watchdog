using System;

namespace Watchdog.Collector.BLL.Entities
{
    public class IssueMessage
    {
        public DateTime OccurredOn { get; set; }
        
        public IssueMessageDetails IssueDetails { get; set; }
    }
}