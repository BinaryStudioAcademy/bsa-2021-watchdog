using System;
using Newtonsoft.Json;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.Enums.Issues;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueInfoDto
    {
        public int IssueId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public IssueStatus Status { get; set; }
        public int EventsCount { get; set; }
        public IssueMessageDto Newest { get; set; }
        public DateTime OccurredOn => Newest.OccurredOn;
        [JsonProperty("project")]
        public ApplicationDto Application { get; set; }
        public string ProjectName => Application?.Name;
        public AssigneeDto Assignee { get; set; }
    }
}