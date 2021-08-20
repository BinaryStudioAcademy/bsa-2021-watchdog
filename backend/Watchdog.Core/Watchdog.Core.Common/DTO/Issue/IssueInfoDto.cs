using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueInfoDto
    {
        public string IssueId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public int EventsCount { get; set; }
        public IssueMessageDto Newest { get; set; }
        public Assignee Assignee { get; set; }
    }
}