using Newtonsoft.Json;
using System;
using Watchdog.Core.Common.DTO.Application;

namespace Watchdog.Core.Common.Models.Issue
{
    public class IssueMessage
    {
        public string Id { get; set; }
        public int IssueId { get; set; }
        public string ApiKey { get; set; }

        [JsonProperty("project")]
        public ApplicationDto Application { get; set; }

        public DateTime OccurredOn { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
    }
}