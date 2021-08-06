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

        public async Task<IEnumerable<ApplicationDto>> GetApplicationsByApplicationId(int id)
        {
            var applications = await _context.Applications.Include(a => a.Platform).Where(a => a.OrganizationId == id).ToListAsync();
            return _mapper.Map<IEnumerable<ApplicationDto>>(applications);
        }
    }
}
