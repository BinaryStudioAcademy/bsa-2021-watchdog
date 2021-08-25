using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Dashboard;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using System.Linq;
using System.Text.RegularExpressions;

namespace Watchdog.Core.BLL.Services
{
    public class DashboardService : BaseService, IDashboardService
    {
        public DashboardService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<ICollection<DashboardDto>> GetAllDashboardsByOrganizationAsync(int organizationId)
        {
            var dashboards = await _context.Dashboards
                .Where(dashboard => dashboard.OrganizationId == organizationId)
                .ToListAsync();

            return _mapper.Map<ICollection<DashboardDto>>(dashboards);
        }

        public async Task<DashboardDto> GetDashboardAsync(int dashboardId)
        {
            var dashboard = await _context.Dashboards
                .FirstOrDefaultAsync(dashboard => dashboard.Id == dashboardId);

            return _mapper.Map<DashboardDto>(dashboard);
        }

        public async Task<DashboardDto> CreateDashboardAsync(NewDashboardDto newDashboard)
        {
            var dashboard = _mapper.Map<Dashboard>(newDashboard, opts => opts.AfterMap((src, dst) =>
            {
                dst.CreatedAt = DateTime.UtcNow;
            }));

            _context.Add(dashboard);
            await _context.SaveChangesAsync();

            return _mapper.Map<DashboardDto>(dashboard);
        }

        public async Task<DashboardDto> UpdateDashboardAsync(UpdateDashboardDto updateDashboard)
        {
            var existedDashboard = await _context.Dashboards.FirstOrDefaultAsync(t => t.Id == updateDashboard.Id);

            var mergedDashboard = _mapper.Map(updateDashboard, existedDashboard);

            var updatedDashboard = _context.Update(mergedDashboard);
            await _context.SaveChangesAsync();

            return _mapper.Map<DashboardDto>(updatedDashboard.Entity);
        }

        public async Task DeleteDashboardAsync(int dashboardId)
        {
            var dashboard = await _context.Dashboards.FirstOrDefaultAsync(t => t.Id == dashboardId);
            _context.Remove(dashboard);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsDashboardNameValid(string dashboardName, int organizationId)
        {
            if (dashboardName.Length < 3 || dashboardName.Length > 50)
            {
                return false;
            }

            return !(await _context.Dashboards
                .Where(o => o.OrganizationId == organizationId)
                .AnyAsync(d => d.Name == dashboardName));
        }
    }
}