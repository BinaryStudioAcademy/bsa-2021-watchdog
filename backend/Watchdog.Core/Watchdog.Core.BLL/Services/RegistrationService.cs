using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
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
            await _context.Users.AddAsync(user);

            return await CreateOrganizationAsync(fullRegistrationDto.Organization, user);
        }

        public async Task<UserDto> FullRegistrationWithJoinAsync(FullRegistrationWithJoinDto fullRegistrationWithJoinDto)
        {
            var user = _mapper.Map<User>(fullRegistrationWithJoinDto.User);
            if (await _context.Users.AnyAsync(u => u.Email == fullRegistrationWithJoinDto.User.Email))
                throw new InvalidOperationException("Such email alreaby exists");
            if (await _context.Organizations.AnyAsync(o => o.OrganizationSlug != fullRegistrationWithJoinDto.OrganizationSlug))
                throw new InvalidOperationException("Organization doesn't exist");
            user.RegisteredAt = DateTime.Now;
            await _context.Users.AddAsync(user);

            return await JoinToOrganizationAsync(fullRegistrationWithJoinDto.OrganizationSlug, user);
        }

        public async Task<UserDto> PartialRegistrationAsync(PartialRegistrationDto partialRegistrationDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == partialRegistrationDto.UserId);
            user.RegisteredAt = DateTime.Now;
            _context.Users.Update(user);

            return await CreateOrganizationAsync(partialRegistrationDto.Organization, user);
        }

        private async Task<UserDto> JoinToOrganizationAsync(string organizationSlug, User user)
        {
            var roles = await _context.Roles.ToListAsync();
            var organization = await _context.Organizations.FirstOrDefaultAsync(s => s.OrganizationSlug == organizationSlug);
            var ownerOrganization = await _context.Users.Include(o => o.Organizations).FirstOrDefaultAsync(s => s.Id == organization.CreatedBy);

            var member = new Member
            {
                User = user,
                CreatedByUser = ownerOrganization,
                Organization = organization,
                Role = roles.First(r => r.Name.ToLower() == "viewer"),
                IsAccepted = false
            };
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        private async Task<UserDto> CreateOrganizationAsync(RegOrganizationDto regOrganization, User user)
        {
            var roles = await _context.Roles.ToListAsync();
            var organization = _mapper.Map<Organization>(regOrganization);
            organization.User = user;
            organization.CreatedAt = DateTime.Now;
            organization.DefaultRoleId = roles.First(r => r.Name.ToLower() == "viewer").Id;
            organization.OpenMembership = true;
            await _context.Organizations.AddAsync(organization);

            var member = new Member
            {
                User = user,
                CreatedByUser = user,
                CreatedAt = DateTime.Now,
                Organization = organization,
                Role = roles.First(r => r.Name.ToLower() == "owner"),
                IsAccepted = true
            };
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

    }
}
