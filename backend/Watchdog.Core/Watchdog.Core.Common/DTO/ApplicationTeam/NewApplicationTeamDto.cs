using Newtonsoft.Json;

namespace Watchdog.Core.Common.DTO.ApplicationTeam
{
    public class NewApplicationTeamDto
    {
        public int TeamId { get; set; }
        [JsonProperty("projectId")]
        public int ApplicationId { get; set; }
    }
}
