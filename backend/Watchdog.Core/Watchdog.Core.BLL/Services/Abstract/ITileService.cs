using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Dashboard;
using Watchdog.Core.Common.DTO.Tile;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface ITileService
    {
        Task<TileDto> GetTileAsync(int tileId);
        Task<TileDto> CreateTileAsync(NewTileDto newTileDto);
        Task<TileDto> UpdateTileAsync(UpdateTileDto updateTileDto);
        Task DeleteTileAsync(int tileId);
        
        Task<ICollection<TileDto>> GetAllTilesByDashboardIdAsync(int dashboardId);
        Task DeleteAllTilesByDashboardIdAsync(int dashboardId);
    }
}