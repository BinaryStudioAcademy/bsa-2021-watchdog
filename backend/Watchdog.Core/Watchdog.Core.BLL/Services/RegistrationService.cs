using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Registration;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class RegistrationService : BaseService, IRegistrationService
    {
        public RegistrationService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<DateTime> FullRegistrationAsync(FullRegistrationDto fullRegistrationDto)
        {
            var user = _mapper.Map<User>(fullRegistrationDto.User);
            user.RegisteredAt = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var organization = _mapper.Map<Organization>(fullRegistrationDto.Organization);
            organization.CreatedBy = user.Id;
            organization.CreatedAt = DateTime.Now;
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            var member = new Member
            {
                CreatedBy = user.Id,
                CreatedAt = DateTime.Now,
                OrganizationId = organization.Id,
                RoleId = 1,
            };
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return user.RegisteredAt;
        }

        public async Task<DateTime> PartialRegistrationAsync(PartialRegistrationDto partialRegistrationDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == partialRegistrationDto.UserId);
            user.RegisteredAt = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var organization = _mapper.Map<Organization>(partialRegistrationDto.Organization);
            organization.CreatedBy = user.Id;
            organization.CreatedAt = DateTime.Now;
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            var member = new Member
            {
                CreatedBy = user.Id,
                CreatedAt = DateTime.Now,
                OrganizationId = organization.Id,
                RoleId = 1,
            };
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return user.RegisteredAt;
        }
    }
}
