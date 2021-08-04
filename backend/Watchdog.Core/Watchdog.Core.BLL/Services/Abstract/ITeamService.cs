using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Team;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface ITeamService
    {
        Task<ICollection<TeamDto>> GetAllTeamsAsync(int organizationId);
        Task<ICollection<TeamDto>> GetMemberTeamsAsync(int organizationId, int memberId, bool isForMember);
        Task<TeamDto> CreateTeamAsync(NewTeamDto newTeam);
        Task<TeamDto> UpdateTeamAsync(int teamId, UpdateTeamDto updateTeam);
        Task<TeamDto> AddMemberToTeamAsync(TeamMemberDto teamMemberDto);
        Task<TeamDto> LeaveTeamAsync(int teamId, int memberId);
        Task DeleteTeamAsync(int teamId);
    }
}