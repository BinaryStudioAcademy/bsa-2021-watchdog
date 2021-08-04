using System;

namespace Watchdog.Core.Common.DTO.Organization
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}