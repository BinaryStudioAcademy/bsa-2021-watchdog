using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class UpdateAssigneeDto
    {
        public string IssueId { get; set; }
        public Assignee Assignee { get; set; }
    }
}
