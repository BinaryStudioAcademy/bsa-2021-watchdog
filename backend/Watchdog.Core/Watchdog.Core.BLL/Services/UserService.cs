using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(WatchdogCoreContext context, IMapper mapper) : base (context, mapper) { }
        public Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateUserPasswordAsync(int userId, UpdateUserPasswordDto updateUserPassword)
        {
            throw new NotImplementedException();
        }
    }
}
