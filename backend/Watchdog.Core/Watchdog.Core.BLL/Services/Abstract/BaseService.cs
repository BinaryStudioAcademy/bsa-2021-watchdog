using AutoMapper;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public abstract class BaseService
    {
        private protected readonly WatchdogCoreContext _context;
        private protected readonly IMapper _mapper;

        protected BaseService(WatchdogCoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
