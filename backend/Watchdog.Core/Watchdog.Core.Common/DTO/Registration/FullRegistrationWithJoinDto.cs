using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.DTO.Registration
{
    public class FullRegistrationWithJoinDto
    {
        public string OrganizationSlug { get; set; }
        public NewUserDto User { get; set; }
    }
}
