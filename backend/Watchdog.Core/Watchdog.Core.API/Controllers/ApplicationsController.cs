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

        [HttpPut("team/{appTeamId}/favorite/{state}")]
        public async Task<ActionResult<bool>> SetFavoriteAppForTeam(bool state, int appTeamId)
        {
            var updatedState = await _appService.UpdateFavoriteStateAsync(appTeamId, state);
            return Ok(updatedState);
        }

        [HttpDelete("team/{appTeamId}")]
        public async Task<IActionResult> DeleteApplicationFromTeam(int appTeamId)
        {
            await _appService.RemoveAppTeam(appTeamId);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> Create(NewApplicationDto dto)
        {
            var application = await _appService.CreateAppAsync(dto);
            return Created($"/applications/{application.Id}", application);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApplicationDto>> GetApplicationById(int id)
        {
            return Ok(await _appService.GetApplicationByIdAsync(id));
        }

        [HttpPut("appId")]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(int id, UpdateApplicationDto dto)
        {
            var application = await _appService.UpdateApplicationAsync(id, dto);
            return Ok(application);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _appService.DeleteApplicationAsync(id);
            return NoContent();
        }
    }
}
