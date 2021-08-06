using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Role;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IRoleService
    {
        Task<ICollection<RoleDto>> GetRolesAsync();
    }
}
