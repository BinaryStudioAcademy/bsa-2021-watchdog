using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Role;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.BLL.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ICollection<RoleDto>> GetRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<ICollection<RoleDto>>(roles);
        }
    }
}
