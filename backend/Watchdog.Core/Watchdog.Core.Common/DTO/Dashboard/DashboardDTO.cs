using System;

namespace Watchdog.Core.Common.DTO.Dashboard
{
    public class DashboardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User { get; set; }
        public string Icon { get; set; }

        public int OrganizationId { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
