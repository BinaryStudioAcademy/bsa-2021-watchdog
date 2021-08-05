using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Platform;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.BLL.Services
{
    public class PlatformService : BaseService, IPlatformService
    {
        public PlatformService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<PlatformDto>> GetAllPlatformsAsync()
        {
            var platforms = await _context.Platforms.Include(p => p.PlatformTypes).ToListAsync();
            return _mapper.Map<IEnumerable<PlatformDto>>(platforms);
        }

        public async Task<IEnumerable<string>> GetAllPlatformTypeNames()
        {
            return await _context.PlatformTypes.Select(pt => pt.Name).ToListAsync();
        }
    }
}
