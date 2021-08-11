using Watchdog.Core.Common.DTO.Application.AlertSettings;

namespace Watchdog.Core.Common.DTO.Application
{
    public class NewApplicationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlatformId { get; set; }
        public int OrganizationId { get; set; }
        public int TeamId { get; set; }
        public AlertSettingsDto AlertSettings { get; set; }
        public int CreatedBy { get; set; }

    }
}
