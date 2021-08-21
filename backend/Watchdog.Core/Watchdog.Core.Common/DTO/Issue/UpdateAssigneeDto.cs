using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class UpdateAssigneeDto
    {
        public string IssueId { get; set; }
        public AssigneeDto Assignee { get; set; }
    }
}
