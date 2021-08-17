using System;

namespace Watchdog.Notifier.Common.Models.Issue
{
    public class IssueMessage
    {
        public DateTime OccurredOn { get; set; }

        public IssueMessageDetails IssueDetails { get; set; }
    }
}