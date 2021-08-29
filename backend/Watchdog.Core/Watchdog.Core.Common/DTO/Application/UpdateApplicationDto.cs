using Watchdog.Core.Common.DTO.Application.AlertSettings;

namespace Watchdog.Core.Common.DTO.Application
{
    public class UpdateApplicationDto
    {
        public string Name { get; set; }
        
        public string ApiKey { get; set; }

        public string Description { get; set; }

        public int PlatformId { get; set; }

        public AlertSettingsDto AlertSettings { get; set; }
    }
}
