using Watchdog.Core.Common.DTO.Application.AlertSettings;
using Watchdog.Core.Common.DTO.Platform;

namespace Watchdog.Core.Common.DTO.Application
{
    public class ApplicationDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PlatformDto Platform { get; set; }
    }
}