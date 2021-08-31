using Newtonsoft.Json;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.Enums.Issues;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueDto
    {
        public string Id { get; set; }
        public string ErrorClass { get; set; }
        public string ErrorMessage { get; set; }
        public IssueStatus Status { get; set; }
        [JsonProperty("project")]
        public ApplicationDto Application { get; set; }
    }
}