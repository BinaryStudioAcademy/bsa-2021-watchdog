using Newtonsoft.Json;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.Team;

namespace Watchdog.Core.Common.DTO.ApplicationTeam
{
    public class ApplicationTeamDto
    {
        [JsonProperty("projectId")]
        public int ApplicationId { get; set; }

        [JsonProperty("project")]
        public ApplicationDto Application { get; set; }

        public bool IsFavorite { get; set; }

        public int TeamId { get; set; }

        public TeamDto Team { get; set; }
    }
}