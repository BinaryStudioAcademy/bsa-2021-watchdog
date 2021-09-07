using Newtonsoft.Json;

namespace Watchdog.Core.Common.DTO.IssueAnswer
{
    public class IssueItemAnswer
    {
        [JsonProperty("is_accepted")]
        public bool IsAccepted { get; set; }

        [JsonProperty("question_id")]
        public int QuestionId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
