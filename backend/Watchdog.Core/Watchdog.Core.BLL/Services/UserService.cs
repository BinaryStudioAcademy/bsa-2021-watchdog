using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.ExceptionsCustom;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Image;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IImageUpload _imageUpload;
        public UserService(WatchdogCoreContext context, IMapper mapper, IImageUpload imageUpload) : base (context, mapper) 
        {
            _imageUpload = imageUpload;
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == updateUserDto.Id);

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

            return await GetUserAsync(updateUserDto.Id);
        }

        public async Task<UserDto> GetUserAsync(int userId)
        {
            var user = await _context.Users
                .Include(user => user.FirstName)
                .Include(user => user.LastName)
                .Include(user => user.Email)
                .FirstOrDefaultAsync(user => user.Id == userId);

            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAvatar(ImageUploadDto imageUploadDto, int userId)
        {
            var imgUri = await _imageUpload.UploadAsync(imageUploadDto.uri);
            var userEntity = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }
    }
}
