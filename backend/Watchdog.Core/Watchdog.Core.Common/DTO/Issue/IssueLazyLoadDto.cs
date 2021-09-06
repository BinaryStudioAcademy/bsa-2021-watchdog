using Newtonsoft.Json;
using System;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.Enums.Issues;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueLazyLoadDto
    {
        public int IssueId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public IssueStatus Status { get; set; }
        public int EventsCount { get; set; }
        public string NewestId { get; set; }
        public DateTime OccurredOn { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public AssigneeDto Assignee { get; set; }
        public int AffectedUsersCount { get; set; }
    }
}
