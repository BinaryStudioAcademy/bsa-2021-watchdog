using Newtonsoft.Json;

namespace Watchdog.Core.Common.DTO.IssueSolution
{
    public class IssueAnswer
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
