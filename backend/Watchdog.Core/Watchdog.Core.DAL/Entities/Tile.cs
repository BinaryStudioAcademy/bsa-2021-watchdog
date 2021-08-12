using Watchdog.Core.Common.Enums.Tiles;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Tile : AuditEntity<int>
    {
        public string Name { get; set; }
        public TileCategory Category { get; set; }
        public TileType Type { get; set; }
        public User User { get; set; }
        public int DashboardId { get; set; }
        public Dashboard Dashboard { get; set; }
        public string Settings { get; set; }
    }
}