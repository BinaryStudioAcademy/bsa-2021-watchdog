using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Organization;
using Watchdog.Core.Common.DTO.Registration;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class RegistrationService : BaseService, IRegistrationService
    {
        public RegistrationService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserDto> FullRegistrationAsync(FullRegistrationDto fullRegistrationDto)
        {
            var user = _mapper.Map<User>(fullRegistrationDto.User);
            if (await _context.Users.AnyAsync(u => u.Email == fullRegistrationDto.User.Email))
                throw new InvalidOperationException("Such email alreaby exists");
            user.RegisteredAt = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await CreateOrganizationAsync(fullRegistrationDto.Organization, user);
        }

        public async Task<UserDto> PartialRegistrationAsync(PartialRegistrationDto partialRegistrationDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == partialRegistrationDto.UserId);
            user.RegisteredAt = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return await CreateOrganizationAsync(partialRegistrationDto.Organization, user);
        }

        private async Task<UserDto> CreateOrganizationAsync(RegOrganizationDto regOrganization, User user)
        {
            var organization = _mapper.Map<Organization>(regOrganization);
            organization.CreatedBy = user.Id;
            organization.CreatedAt = DateTime.Now;
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            var member = new Member
            {
                UserId = user.Id,
                CreatedBy = user.Id,
                CreatedAt = DateTime.Now,
                OrganizationId = organization.Id,
                RoleId = 1,
                IsAccepted = true
            };
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
