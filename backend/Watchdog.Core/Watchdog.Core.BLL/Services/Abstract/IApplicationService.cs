using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.ApplicationTeam;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IApplicationService
    {
        Task<ICollection<ApplicationDto>> GetAppsByOrganizationIdAsync(int organizationId);
        Task<ICollection<ApplicationTeamDto>> GetAppsByTeamIdAsync(int teamId);
        Task<ICollection<ApplicationDto>> SearchAppsNotInTeamAsync(int teamId, string teamName);
        Task<ApplicationTeamDto> AddAppTeamAsync(NewApplicationTeamDto appTeam);
        Task<bool> UpdateFavoriteStateAsync(int appTeamId, bool state);
        Task RemoveAppTeam(int appTeamId);
    }
}
