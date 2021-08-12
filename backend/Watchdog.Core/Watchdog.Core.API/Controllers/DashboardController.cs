using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Dashboard;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashboardService _dashboardService;

        public DashboardController(ILogger<DashboardController> logger, IDashboardService dashboardService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<ICollection<DashboardDto>>> GetByOrganization(int organizationId)
        {
            var dashboards = await _dashboardService.GetAllDashboardsByOrganizationAsync(organizationId);
            return Ok(dashboards); 
        }

        [HttpGet("{dashboardId}")]
        public async Task<ActionResult<DashboardDto>> Get(int dashboardId)
        {
            var dashboard = await _dashboardService.GetDashboardAsync(dashboardId);
            return Ok(dashboard);
        }

        [HttpPost]
        public async Task<ActionResult<DashboardDto>> Post(NewDashboardDto newDashboard)
        {
            var createdDashboard = await _dashboardService.CreateDashboardAsync(newDashboard);
            return Ok(createdDashboard);
        }

        [HttpPut]
        public async Task<ActionResult<DashboardDto>> Put(UpdateDashboardDto updateDashboard)
        {
            var updatedDashboard = await _dashboardService.UpdateDashboardAsync(updateDashboard);
            return Ok(updatedDashboard);
        }

        [HttpDelete("{dashboardId}")]
        public async Task<ActionResult> Delete(int dashboardId)
        {
            await _dashboardService.DeleteDashboardAsync(dashboardId);
            _logger.LogInformation($"Dashboard: ID = {dashboardId} has been removed.");
            return NoContent();
        }
    }
}
