namespace Watchdog.Core.Common.DTO.Organization
{
    public class SettingsOrganizationDto
    {
        public string OrganizationSlug { get; set; }
        public string Name { get; set; }
        public bool OpenMembership { get; set; }
        public bool TrelloIntegration { get; set; }
        public string TrelloBoard { get; set; }
        public int DefaultRoleId { get; set; }
    }
}
