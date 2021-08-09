using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class ApplicationService : BaseService, IApplicationService
    {
        public ApplicationService(WatchdogCoreContext context, IMapper mapper) 
            : base(context, mapper) { }

        public async Task<IEnumerable<ApplicationDto>> GetApplicationsByApplicationIdAsync(int id)
        {
            var applications = await _context.Applications.Include(a => a.Platform).Where(a => a.OrganizationId == id).ToListAsync();
            return _mapper.Map<IEnumerable<ApplicationDto>>(applications);
        }

        public async Task<ApplicationDto> CreateApplicationAsync(NewApplicationDto dto)
        {
            var application = _mapper.Map<Application>(dto);
            await _context.AddAsync(application);
            await _context.SaveChangesAsync();
            return _mapper.Map<ApplicationDto>(application);
        }
    }
}
