using Watchdog.Core.Common.DTO.Application.AlertSettings;
using Watchdog.Core.Common.DTO.ApplicationTeam;

namespace Watchdog.Core.Common.DTO.Application
{
    public class UpdateApplicationDto
    {
        public string Name { get; set; }
        
        public string ApiKey { get; set; }

        public string Description { get; set; }

        public int PlatformId { get; set; }

        public AlertSettingsDto AlertSettings { get; set; }

        public ApplicationRecipientsDto[] RecipientTeams { get; set; }
    }
}
