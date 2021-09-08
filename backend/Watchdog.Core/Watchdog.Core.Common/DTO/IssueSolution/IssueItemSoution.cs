using Newtonsoft.Json;
using System.Collections.Generic;

namespace Watchdog.Core.Common.DTO.IssueSolution
{
    public class IssueItemSolution
    {
        [JsonProperty("is_answered")]
        public bool IsAnswered { get; set; }
        [JsonProperty("view_count")]
        public int ViewCount { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public ICollection<IssueAnswer> Answers { get; set; }
    }
}

