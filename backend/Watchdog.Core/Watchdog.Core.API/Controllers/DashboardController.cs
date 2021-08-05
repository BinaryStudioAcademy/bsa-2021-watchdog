﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
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

        [HttpGet]
        public async Task<ActionResult<ICollection<DashboardDto>>> Get()
        {
            var dashboards = await _dashboardService.GetAllDashboardsAsync();
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdDashboard = await _dashboardService.CreateDashboardAsync(newDashboard);
            return Ok(createdDashboard);
        }

        [HttpPut("{dashboardId}")]
        public async Task<ActionResult<DashboardDto>> Put(int dashboardId, NewDashboardDto newDashboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedDashboard = await _dashboardService.UpdateDashboardAsync(dashboardId, newDashboard);
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