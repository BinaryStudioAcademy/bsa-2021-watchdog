using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Dashboard;
using Watchdog.Core.Common.DTO.Tile;

namespace Watchdog.Core.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TilesController : ControllerBase
    {
        private readonly ILogger<TilesController> _logger;
        private readonly ITileService _tileService;

        public TilesController(ILogger<TilesController> logger, ITileService tileService)
        {
            _logger = logger;
            _tileService = tileService;
        }


        [HttpGet("{tileId:int}")]
        public async Task<ActionResult<TileDto>> Get(int tileId)
        {
            var tile = await _tileService.GetTileAsync(tileId);
            return Ok(tile);
        }

        [HttpPost]
        public async Task<ActionResult<TileDto>> Post(NewTileDto newTileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdTile = await _tileService.CreateTileAsync(newTileDto);
            return Ok(createdTile);
        }

        [HttpPut]
        public async Task<ActionResult<TileDto>> Put(UpdateTileDto updateTileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedTile = await _tileService.UpdateTileAsync(updateTileDto);
            return Ok(updatedTile);
        }

        [HttpDelete("{tileId:int}")]
        public async Task<ActionResult> Delete(int tileId)
        {
            await _tileService.DeleteTileAsync(tileId);
            _logger.LogInformation($"Tile: ID = {tileId} has been removed.");
            return NoContent();
        }

        [HttpGet("dashboard/{dashboardId:int}")]
        public async Task<ActionResult<ICollection<DashboardDto>>> GetAllByDashboardId(int dashboardId)
        {
            var tiles = await _tileService.GetAllTilesByDashboardIdAsync(dashboardId);
            return Ok(tiles);
        }

        [HttpDelete("dashboard/{dashboardId:int}")]
        public async Task<ActionResult<ICollection<DashboardDto>>> DeleteAllByDashboardId (int dashboardId)
        {
            await _tileService.DeleteAllTilesByDashboardIdAsync(dashboardId);
            _logger.LogInformation($"All tiles from Dashboard: ID = {dashboardId} has been removed.");
            return NoContent();
        }

        [HttpPost("dashboard/{dashboardId:int}/setOrder")]
        public async Task<ActionResult<ICollection<TileDto>>> SetOrderForTiles(int dashboardId, ICollection<TileOrderDto> tiles)
        {
            var orderedTiles = await _tileService.SetOrderForTilesAsync(dashboardId, tiles);
            return Ok(orderedTiles);
        }
    }
}