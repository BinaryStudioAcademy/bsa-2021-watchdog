using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUser);
        Task<UserDto> UpdateUserPasswordAsync(int userId, UpdateUserPasswordDto updateUserPassword);
        Task<UserDto> GetUserAsync(int userId);
    }
}
