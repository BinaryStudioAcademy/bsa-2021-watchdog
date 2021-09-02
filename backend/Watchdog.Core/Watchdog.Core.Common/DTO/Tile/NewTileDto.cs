using Watchdog.Core.Common.Enums.Tiles;

namespace Watchdog.Core.Common.DTO.Tile
{
    public class NewTileDto
    {
        public string Name { get; set; }
        public TileCategory Category { get; set; }
        public TileType Type { get; set; }
        public int DashboardId { get; set; }
        public string Settings { get; set; }
        public int TileOrder { get; set; }
        public int CreatedBy { get; set; }
    }
}