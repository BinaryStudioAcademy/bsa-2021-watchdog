using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(WatchdogCoreContext context, IMapper mapper) : base (context, mapper) { }
        public async Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUser)
        {
            var user = await _context.Users.FirstAsync(u => u.Id == userId);

            var userUpdateInfo = _mapper.Map(updateUser, user);

            var updatedUserInfo = _context.Update(userUpdateInfo);
            await _context.SaveChangesAsync();

            return await GetUserAsync(updatedUserInfo.Entity.Id);
        }

        public async Task<UserDto> UpdateUserPasswordAsync(int userId, UpdateUserPasswordDto updateUserPassword)
        {
            var user = await _context.Users.FirstAsync(u => u.Id == userId);

            var userUpdatePassword = _mapper.Map(updateUserPassword, user);

            var updatedUserPassword = _context.Update(userUpdatePassword);
            await _context.SaveChangesAsync();

            return await GetUserAsync(updatedUserPassword.Entity.Id);
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var user = await _context.Users.FirstAsync(u => u.Id == userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
