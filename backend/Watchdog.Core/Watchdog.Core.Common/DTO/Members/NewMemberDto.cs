namespace Watchdog.Core.Common.DTO.Members
{
    public class NewMemberDto
    {
        public int RoleId { get; set; }

        public int CreatedBy { get; set; }

        public int OrganizationId { get; set; }

        public string Email { get; set; }

        public int TeamId { get; set; }
    }
}