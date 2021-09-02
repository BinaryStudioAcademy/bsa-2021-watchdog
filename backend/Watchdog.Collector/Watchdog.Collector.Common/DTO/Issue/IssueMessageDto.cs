using System;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Collector.Common.DTO.Issue
{
    public class IssueMessageDto
    {
        public DateTime OccurredOn { get; set; }
        public string ApiKey { get; set; }
        public AffectedUser User { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
    }
}