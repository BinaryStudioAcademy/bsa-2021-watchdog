using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Application;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IApplicationService
    {
        Task<ICollection<ApplicationDto>> GetApplicationsByOrganizationIdAsync(int organizationId);
        Task<ICollection<ApplicationDto>> GetApplicationsByTeamIdAsync(int teamId);
    }
}
