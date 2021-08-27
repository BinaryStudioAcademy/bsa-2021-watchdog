using System;
using Watchdog.Collector.Common.Models;

namespace Watchdog.Collector.Common.DTO.Issue
{
    public class IssueMessageDto
    {
        public DateTime OccurredOn { get; set; }
        public string ApiKey { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
    }
}