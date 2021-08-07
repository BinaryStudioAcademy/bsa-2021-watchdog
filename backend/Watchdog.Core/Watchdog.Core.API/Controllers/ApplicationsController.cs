using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetApplicationsByOrganization(int organizationId)
        {
            return Ok(await _applicationService.GetApplicationsByOrganizationIdAsync(organizationId));
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetApplicationsByTeam(int teamId)
        {
            return Ok(await _applicationService.GetApplicationsByTeamIdAsync(teamId));
        }
    }
}
