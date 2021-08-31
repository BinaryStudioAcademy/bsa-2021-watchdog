using System;
using Watchdog.Core.Common.Enums.Issues;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueMessageDto
    {
        public string Id { get; set; }
        public IssueStatus Status { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}