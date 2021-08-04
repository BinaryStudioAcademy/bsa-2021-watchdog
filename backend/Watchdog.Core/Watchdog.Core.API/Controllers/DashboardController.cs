using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;

        public DashboardController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<string>>> Get()
        {
            return Ok(new string[] { "value1", "value2" }); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int dashboardId)
        {
            return Ok("value");
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int dashboardId)
        {
            _logger.LogInformation($"Dashboard: ID = {dashboardId} has been removed.");
            return NoContent();
        }
    }
}
