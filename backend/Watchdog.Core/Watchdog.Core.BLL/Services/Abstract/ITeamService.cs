using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Team;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface ITeamService
    {
        Task<TeamDto> GetTeamAsync(int teamId);
        Task<ICollection<TeamDto>> GetAllTeamsAsync(int organizationId);
        Task<ICollection<TeamOptionDto>> GetTeamsOptionsByOrganizationIdAsync(int organizationId);
        Task<ICollection<TeamDto>> GetMemberTeamsAsync(int organizationId, int memberId, bool isForMemberInTeam);
        Task<TeamDto> CreateTeamAsync(NewTeamDto newTeam);
        Task<TeamDto> UpdateTeamAsync(int teamId, UpdateTeamDto updateTeam);
        Task<TeamDto> AddMemberToTeamAsync(TeamMemberDto teamMemberDto);
        Task<TeamDto> LeaveTeamAsync(int teamId, int memberId);
        Task DeleteTeamAsync(int teamId);
        Task<bool> IsTeamNameUniqueAsync(int orgId, string teamName);
        Task<ICollection<TeamDto>> GetTeamsForAssigneeByOrganizationIdAsync(int orgId);
    }
}