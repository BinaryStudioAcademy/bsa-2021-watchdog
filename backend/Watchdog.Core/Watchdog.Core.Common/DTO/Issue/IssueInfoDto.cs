using System;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueInfoDto
    {
        public int IssueId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public int EventsCount { get; set; }
        public IssueMessageDto Newest { get; set; }
        public DateTime OccurredOn => Newest.OccurredOn;
        public int Affected { get; set; } = 1; // Temp TODO remove autosetting property 
        public AssigneeDto Assignee { get; set; }
    }
}