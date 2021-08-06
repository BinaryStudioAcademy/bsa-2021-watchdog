using System.Collections.Generic;
using Watchdog.Core.Common.DTO.Organization;
using Watchdog.Core.Common.DTO.Platform;

namespace Watchdog.Core.Common.DTO.Application
{
    public class ApplicationDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SecurityToken { get; set; }

        public PlatformDto Platform { get; set; }

    }
}