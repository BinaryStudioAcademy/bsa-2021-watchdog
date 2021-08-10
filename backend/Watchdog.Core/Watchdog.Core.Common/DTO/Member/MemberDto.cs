using System;

namespace Watchdog.Core.Common.DTO.Member
{
    public class MemberDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public int OrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}