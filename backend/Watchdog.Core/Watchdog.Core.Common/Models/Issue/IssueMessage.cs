using System;

namespace Watchdog.Core.Common.Models.Issue
{
    public class IssueMessage
    {
        public string Id { get; set; }
        public int IssueId { get; set; }
        public string ApiKey { get; set; }
        public DateTime OccurredOn { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
    }
}