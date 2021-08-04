using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Team;

namespace Watchdog.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamService _teamService;

        public TeamController(ILogger<TeamController> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ICollection<TeamDto>>> GetAllAsync()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }
            
        [HttpGet("{teamId:int}")]
        public async Task<ActionResult<TeamDto>> GetByIdAsync(int teamId)
        {
            var team = await _teamService.GetTeamAsync(teamId);
            return Ok(team);
        }
        
        [HttpGet("user/{userId:int}")]
        public async Task<ActionResult<TeamDto>> GetByUserAsync(int userId)
        {
            var team = await _teamService.GetUserTeamsAsync(userId);
            return Ok(team);
        }
        
        [HttpGet("not-user/{userId:int}")]
        public async Task<ActionResult<TeamDto>> GetNotUserAsync(int userId)
        {
            var team = await _teamService.GetNotUserTeamsAsync(userId);
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamDto>> CreateAsync(NewTeamDto newTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdTeam = await _teamService.CreateTeamAsync(newTeam);
            return Ok(createdTeam);
        }
        
        [HttpPost("joinTeam")]
        public async Task<ActionResult<TeamDto>> AddMemberAsync(TeamMemberDto teamMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updatedTeam = await _teamService.AddMemberToTeamAsync(teamMember);
            return Ok(updatedTeam);
        }
        
        [HttpPut("{teamId:int}")]
        public async Task<ActionResult<TeamDto>> UpdateAsync(int teamId, UpdateTeamDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var updateTeam = await _teamService.UpdateTeamAsync(teamId, updateDto);
            return Ok(updateTeam);
        }
            
        [HttpDelete("leave_team/{teamId:int}/member/{memberId:int}")]
        public async Task<ActionResult> LeaveFromTeamAsync(int teamId, int memberId)
        {
            var updatedTeam = await _teamService.LeaveTeamAsync(teamId, memberId);
            return Ok(updatedTeam);
        }
        
        [HttpDelete("{teamId:int}")]
        public async Task<ActionResult> DeleteAsync(int teamId)
        {
            await _teamService.DeleteTeamAsync(teamId);
            
            return NoContent();
        }
    }
}
