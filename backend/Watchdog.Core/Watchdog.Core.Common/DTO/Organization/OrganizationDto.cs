using System;

namespace Watchdog.Core.Common.DTO.Organization
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string OrganizationSlug { get; set; }
        public string Name { get; set; }
        public bool OpenMembership { get; set; }
        public bool TrelloIntegration { get; set; }
        public string TrelloBoard { get; set; }
        public int DefaultRoleId { get; set; }
        public string AvatarUrl { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
