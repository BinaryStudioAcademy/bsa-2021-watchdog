using Watchdog.Core.Common.DTO.Organization;

namespace Watchdog.Core.Common.DTO.Registration
{
    public class PartialRegistrationDto
    {
        public RegOrganizationDto Organization { get; set; }
        public int UserId { get; set; }
    }
}
