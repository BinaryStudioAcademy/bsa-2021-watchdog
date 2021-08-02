namespace Watchdog.Core.Common.DTO.Organization
{
    public class NewOrganizationDto
    {
        public string OrganizationSlug { get; set; }
        public string Name { get; set; }
        public bool OpenMembership { get; set; }
        public int DefaultRoleId { get; set; }
        public string AvatarUrl { get; set; }
        public int CreatedBy { get; set; }
    }
}
