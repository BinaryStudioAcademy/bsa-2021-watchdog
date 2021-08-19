using System;

namespace Watchdog.Collector.Common.Models
{
    public class IssueMessage
    {
        public string IssueId { get; set; }
        public DateTime OccurredOn { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
    }
}