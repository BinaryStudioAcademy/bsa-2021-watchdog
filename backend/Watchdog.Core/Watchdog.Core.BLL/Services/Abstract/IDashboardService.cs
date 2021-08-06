using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Dashboard;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IDashboardService
    {
        Task<ICollection<DashboardDto>> GetAllDashboardsByOrganizationAsync(int organizationId);
        Task<DashboardDto> GetDashboardAsync(int dashboardId);
        Task<DashboardDto> CreateDashboardAsync(NewDashboardDto newDashboard);
        Task<DashboardDto> UpdateDashboardAsync(UpdateDashboardDto updateDashboard);
        Task DeleteDashboardAsync(int dashboardId);
    }
}
