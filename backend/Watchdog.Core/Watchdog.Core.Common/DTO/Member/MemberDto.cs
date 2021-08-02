using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.DTO.Member
{
    public class MemberDto
    {
        private int Id { get; set; }
        public UserDto User { get; set; }
        public int OrganizationId { get; set; }
    }
}