using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Dashboard;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class DashboardService : BaseService, IDashboardService
    {
        public DashboardService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<ICollection<DashboardDto>> GetAllDashboardsAsync()
        {
            var dashboards = await _context.Dashboards
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
                dst.CreatedAt = DateTime.Now;
            }));

            var createdDashboard = _context.Add(dashboard);
            await _context.SaveChangesAsync();

            return _mapper.Map<DashboardDto>(createdDashboard);
        }

        public async Task<DashboardDto> UpdateDashboardAsync(int dashboardId, NewDashboardDto updateDashboard)
        {
            var existedDashboard = await _context.Dashboards.FirstAsync(t => t.Id == dashboardId);

            var mergedDashboard = _mapper.Map(updateDashboard, existedDashboard);

            var updatedDashboard = _context.Update(mergedDashboard);
            await _context.SaveChangesAsync();

            return _mapper.Map<DashboardDto>(await GetDashboardAsync(updatedDashboard.Entity.Id));
        }

        public async Task DeleteDashboardAsync(int dashboardId)
        {
            var dashboard = await _context.Dashboards.FirstAsync(t => t.Id == dashboardId);
            _context.Remove(dashboard);

            await _context.SaveChangesAsync();
        }
    }
}