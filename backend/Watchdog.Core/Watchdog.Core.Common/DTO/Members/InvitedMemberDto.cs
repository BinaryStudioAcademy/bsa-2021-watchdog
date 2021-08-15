using System.Net;

namespace Watchdog.Core.Common.DTO.Members
{
    public class InvitedMemberDto
    {
        public MemberDto Member { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
