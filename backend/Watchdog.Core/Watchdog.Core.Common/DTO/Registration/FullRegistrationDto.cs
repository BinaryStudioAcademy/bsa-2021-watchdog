using Watchdog.Core.Common.DTO.Organization;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.DTO.Registration
{
    public class FullRegistrationDto
    {
        public RegOrganizationDto Organization { get; set; }
        public NewUserDto User { get; set; }
    }
}
