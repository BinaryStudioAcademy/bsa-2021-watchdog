using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDto> UpdateUserAsync(UpdateUserDto updateUser);
        Task<UserDto> GetUserByIdAsync(int userId);
    }
}
