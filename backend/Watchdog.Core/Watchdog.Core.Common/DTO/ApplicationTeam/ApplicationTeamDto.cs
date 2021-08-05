using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.Team;

namespace Watchdog.Core.Common.DTO.ApplicationTeam
{
    public class ApplicationTeamDto
    {
        public int ApplicationId { get; set; }
        
        public ApplicationDto Application { get; set; }
        
        public int TeamId { get; set; }

        public TeamDto Team { get; set; }
    }
}