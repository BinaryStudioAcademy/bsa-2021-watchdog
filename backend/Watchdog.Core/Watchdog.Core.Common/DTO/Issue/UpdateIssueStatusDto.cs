using Watchdog.Core.Common.Enums.Issues;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class UpdateIssueStatusDto
    {
        public int IssueId { get; set; }
        public IssueStatus Status { get; set; }
    }
}