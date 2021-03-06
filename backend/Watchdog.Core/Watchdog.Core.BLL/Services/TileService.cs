using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Tile;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class TileService : BaseService, ITileService
    {
        public TileService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<TileDto> GetTileAsync(int tileId)
        {
            var tileEntity = await _context.Tiles
                .AsNoTracking()
                .FirstOrDefaultAsync(tile => tile.Id == tileId);

            return _mapper.Map<TileDto>(tileEntity);
        }

        public async Task<TileDto> CreateTileAsync(NewTileDto newTileDto)
        {
            var tile = _mapper.Map<Tile>(newTileDto, opts =>
                opts.AfterMap((_, dst) => { dst.CreatedAt = DateTime.UtcNow; }));

            await _context.AddAsync(tile);
            await _context.SaveChangesAsync();
            return _mapper.Map<TileDto>(tile);
        }

        public async Task<TileDto> UpdateTileAsync(UpdateTileDto updateTileDto)
        {
            var existedTile = await _context.Tiles.FirstOrDefaultAsync(t => t.Id == updateTileDto.Id);

            var mergedTile = _mapper.Map(updateTileDto, existedTile);

            var updatedTile = _context.Update(mergedTile);
            await _context.SaveChangesAsync();

            return _mapper.Map<TileDto>(updatedTile.Entity);
        }

        public async Task DeleteTileAsync(int tileId)
        {
            var tileEntity = await _context.Tiles.FirstOrDefaultAsync(t => t.Id == tileId);
            _context.Remove(tileEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TileDto>> GetAllTilesByDashboardIdAsync(int dashboardId)
        {
            var tiles = await _context.Tiles
                .AsNoTracking()
                .Where(tile => tile.DashboardId == dashboardId)
                .OrderBy(tile => tile.TileOrder)
                .ToListAsync();

            return _mapper.Map<ICollection<TileDto>>(tiles);
        }

        public async Task DeleteAllTilesByDashboardIdAsync(int dashboardId)
        {
            var tilesEntities = await _context.Tiles
                .Where(tile => tile.DashboardId == dashboardId)
                .ToListAsync();

            _context.RemoveRange(tilesEntities);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TileDto>> SetOrderForTilesAsync(int dashboardId, ICollection<TileOrderDto> tiles)
        {
            var dashboard = await _context.Dashboards.Include(d => d.Tiles).FirstOrDefaultAsync(d => d.Id == dashboardId)
                ?? throw new KeyNotFoundException("No dashboard with this id!");

            foreach (var tile in dashboard.Tiles)
            {
                tile.TileOrder = tiles.FirstOrDefault(t => tile.Id == t.Id)?.TileOrder
                    ?? throw new KeyNotFoundException("No tile with this id in dashboard!");
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<ICollection<TileDto>>(dashboard.Tiles.OrderBy(t => t.TileOrder));
        }
    }
}