using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.ExceptionsCustom;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(WatchdogCoreContext context, IMapper mapper) : base (context, mapper) 
        {
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updateUserDto.Id);

            if (user == null)
            {
                throw new NotFoundException(nameof(user), user.Id);
            }

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Email = updateUserDto.Email;
            user.AvatarUrl = updateUserDto.AvatarUrl;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return await GetUserByIdAsync(updateUserDto.Id);
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await GetUserByIdInternal(userId);

            return _mapper.Map<UserDto>(user);
        }

        private async Task<User> GetUserByIdInternal(int userId)
        {
            return await _context.Users
                .Include(f => f.FirstName)
                .Include(l => l.LastName)
                .Include(e => e.Email)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
