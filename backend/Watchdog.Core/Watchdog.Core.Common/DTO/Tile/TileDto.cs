using Watchdog.Core.Common.DTO.Dashboard;

namespace Watchdog.Core.Common.DTO.Tile
{
    public class TileDto
    {
        public string Name { get; set; }

        public int CreatedBy { get; set; }

        public int DashboardId { get; set; }

        public DashboardDto Dashboard { get; set; }
    }
}
