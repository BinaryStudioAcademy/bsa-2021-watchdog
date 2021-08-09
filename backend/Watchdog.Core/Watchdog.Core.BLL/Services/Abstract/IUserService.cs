using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserAsync(int userId);
        Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
    }
}
