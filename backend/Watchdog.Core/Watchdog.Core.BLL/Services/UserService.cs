﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class UserService: BaseService, IUserService
    {
        public UserService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper) { }
        
        public async Task<ICollection<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByUidAsync(string uid)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Uid == uid);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(NewUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var createdUser = _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(createdUser.Entity);
        }
    }
}
