using Watchdog.Core.Common.DTO.Organization;

namespace Watchdog.Core.Common.DTO.Registration
{
    public class PartialRegistrationWithJoinDto
    {
        public string OrganizationSlug { get; set; }
        public int UserId { get; set; }
    }
}
