using System;

namespace Watchdog.Core.Common.Models.Issue
{
    public class IssueMessage
    {
        public string Id { get; set; }
        public int IssueId { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Platform => IssueDetails.EnvironmentMessage.Platform;
        public string Browser => IssueDetails.EnvironmentMessage.Browser;
        public IssueMessageDetails IssueDetails { get; set; }
    }
}