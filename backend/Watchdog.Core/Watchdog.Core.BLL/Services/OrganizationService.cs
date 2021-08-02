using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Organization;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.BLL.Services
{
    public class OrganizationService : BaseService, IOrganizationService
    {
        public OrganizationService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<OrganizationDto> GetOrganizationAsync(int organizationId)
        {
            var organization = await _context.Organizations.FirstAsync(o => o.Id == organizationId);
            return _mapper.Map<OrganizationDto>(organization);
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync()
        {
            var organizations = await _context.Organizations.ToListAsync();
            return _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
        }

        public async Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, NewOrganizationDto organizationDto)
        {
            var existedOrganization = await _context.Organizations.FirstAsync(o => o.Id == organizationId);

            var mergedOrganization = _mapper.Map(organizationDto, existedOrganization);

            var updatedOrganization = _context.Update(mergedOrganization);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrganizationDto>(updatedOrganization.Entity);
        }

        public async Task<IEnumerable<OrganizationDto>> GetUserOrganizationsAsync(int userId)
        {
            var organizaitons = await _context.Organizations
                .Where(o => o.Members.Any(m => m.User.Id == userId))
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrganizationDto>>(organizaitons);
        }
    }
}
