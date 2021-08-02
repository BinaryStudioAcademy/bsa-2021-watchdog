using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Team;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface ITeamService
    {
        Task<ICollection<TeamDto>> GetAllTeamsAsync();
        Task<TeamDto> GetTeamAsync(int teamId);
        Task<ICollection<TeamDto>> GetUserTeamsAsync(int userId);
        Task<TeamDto> CreateTeamAsync(NewTeamDto newTeam);
        Task<TeamDto> UpdateTeamAsync(int teamId, UpdateTeamDto updateTeam);
        Task DeleteTeamAsync(int teamId);
    }
}