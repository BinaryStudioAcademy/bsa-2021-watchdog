using System;
using System.Collections.Generic;
using Watchdog.Core.Common.DTO.Tile;

namespace Watchdog.Core.Common.DTO.Dashboard
{
    public class DashboardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int OrganizationId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
