using System;
using Watchdog.Core.Common.Enums.Tiles;

namespace Watchdog.Core.Common.DTO.Tile
{
    public class UpdateTileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Settings { get; set; }
    }
}