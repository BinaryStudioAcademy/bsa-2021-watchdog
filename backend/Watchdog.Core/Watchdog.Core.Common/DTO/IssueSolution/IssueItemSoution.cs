using Newtonsoft.Json;

namespace Watchdog.Core.Common.DTO.IssueSolution
{
    public class IssueItemSolution
    {
        [JsonProperty("is_answered")]
        public bool IsAnswered { get; set; }
        [JsonProperty("view_count")]
        public int ViewCount { get; set; }
        [JsonProperty("answer_count")]
        public int AnswerCount { get; set; }
        public int Score { get; set; }
        public string Link { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}

