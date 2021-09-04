using System;

namespace Watchdog.Models.Shared.Issues
{
    public class IssueMessage
    {
        public string Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string ApiKey { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
        public AffectedUser User { get; set; }
        public int? IssueId { get; set; }
    }
}