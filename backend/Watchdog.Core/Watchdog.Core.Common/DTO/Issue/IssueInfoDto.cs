namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueInfoDto
    {
        public int IssueId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public int EventsCount { get; set; }
        public IssueMessageDto Newest { get; set; }
        public AssigneeDto Assignee { get; set; }
    }
}