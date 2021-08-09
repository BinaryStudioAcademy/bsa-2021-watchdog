using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.ApplicationTeam;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _appService;

        public ApplicationsController(IApplicationService appService)
        {
            _appService = appService;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<ICollection<ApplicationDto>>> GetApplicationsByOrganization(int organizationId)
        {
            return Ok(await _appService.GetAppsByOrganizationIdAsync(organizationId));
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<ICollection<ApplicationTeamDto>>> GetApplicationsByTeam(int teamId)
        {
            return Ok(await _appService.GetAppsByTeamIdAsync(teamId));
        }

        [HttpGet("team/{teamId}/exceptTeam/")]
        public async Task<ActionResult<ICollection<ApplicationDto>>> GetApplicationsExceptTeam(int teamId, string appName = "")
        {
            return Ok(await _appService.SearchAppsNotInTeamAsync(teamId, appName));
        }

        [HttpPost("team")]
        public async Task<ActionResult<ApplicationTeamDto>> AddApplicationToTeam(NewApplicationTeamDto appTeam)
        {
            var createdAppTeam = await _appService.AddAppTeamAsync(appTeam);
            return Ok(createdAppTeam);
        }

        [HttpPut("team/{appTeamId}/favorite")]
        public async Task<ActionResult<bool>> SetFavoriteAppForTeam(bool state, int appTeamId)
        {
            var updatedAppTeam = await _appService.UpdateFavoriteStateAsync(appTeamId, state);
            return Ok(updatedAppTeam);
        }
    }
}
