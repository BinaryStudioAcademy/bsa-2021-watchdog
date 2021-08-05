using Watchdog.Core.Common.DTO.Dashboard;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.DTO.Tile
{
    public class TileDto
    {
        public string Name { get; set; }

        public UserDto User { get; set; }

        public int DashboardId { get; set; }

        public DashboardDto Dashboard { get; set; }
    }
}
