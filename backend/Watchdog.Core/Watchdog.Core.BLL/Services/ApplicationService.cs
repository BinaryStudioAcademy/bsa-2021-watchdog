using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.BLL.Services
{
    public class ApplicationService : BaseService, IApplicationService
    {
        public ApplicationService(WatchdogCoreContext context, IMapper mapper)
            : base(context, mapper) { }

        public async Task<ICollection<ApplicationDto>> GetApplicationsByOrganizationIdAsync(int organizationId)
        {
            var applications = await _context.Applications
                .Include(a => a.Platform)
                .Where(a => a.OrganizationId == organizationId)
                .ToListAsync();
            return _mapper.Map<ICollection<ApplicationDto>>(applications);
        }

        public async Task<ICollection<ApplicationDto>> GetApplicationsByTeamIdAsync(int teamId)
        {
            var applications = await _context.Applications
                .Include(a => a.Platform)
                .Include(a => a.ApplicationTeams)
                .Where(a => a.ApplicationTeams.Any(t => t.TeamId == teamId))
                .ToListAsync();
            return _mapper.Map<ICollection<ApplicationDto>>(applications);
        }
    }
}
