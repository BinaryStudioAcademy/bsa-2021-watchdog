using System;

namespace Watchdog.Core.Common.Models.Issue
{
    public class IssueMessage
    {
        public string Id { get; set; }
        public string IssueId { get; set; }
        public DateTime OccurredOn { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
    }
}