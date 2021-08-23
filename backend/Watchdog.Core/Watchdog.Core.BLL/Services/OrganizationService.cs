﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Organization;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

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

        public async Task<ICollection<OrganizationDto>> GetAllOrganizationsAsync()
        {
            var organizations = await _context.Organizations.ToListAsync();
            return _mapper.Map<ICollection<OrganizationDto>>(organizations);
        }

        public async Task<OrganizationDto> CreateOrganizationAsync(NewOrganizationDto organizationDto)
        {
            var organization = _mapper.Map<Organization>(organizationDto);

            await _context.Organizations.AddAsync(organization);

            var member = new Member
            {
                UserId = organizationDto.CreatedBy,
                CreatedBy = organizationDto.CreatedBy,
                CreatedAt = DateTime.Now,
                Organization = organization,
                RoleId = 1,
                IsAccepted = true
            };
            await _context.Members.AddAsync(member);

            await _context.SaveChangesAsync();

            return _mapper.Map<OrganizationDto>(organization);
        }

        public async Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, NewOrganizationDto organizationDto)
        {
            var existedOrganization = await _context.Organizations.FirstAsync(o => o.Id == organizationId);

            var mergedOrganization = _mapper.Map(organizationDto, existedOrganization);

            var updatedOrganization = _context.Update(mergedOrganization);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrganizationDto>(updatedOrganization.Entity);
        }

        public async Task<OrganizationDto> UpdateSettingsAsync(int organizationId, SettingsOrganizationDto settingsDto)
        {
            var existedOrganization = await _context.Organizations.FirstAsync(o => o.Id == organizationId);

            var mergedOrganization = _mapper.Map(settingsDto, existedOrganization);

            var updatedOrganization = _context.Update(mergedOrganization);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrganizationDto>(updatedOrganization.Entity);
        }

        public async Task<ICollection<OrganizationDto>> GetUserOrganizationsAsync(int userId)
        {
            var organizaitons = await _context.Organizations
                .Where(o => o.Members.Any(m => m.User.Id == userId))
                .ToListAsync();

            return _mapper.Map<ICollection<OrganizationDto>>(organizaitons);
        }

        public async Task<bool> IsOrganizationSlugValid(string organizationSlug)
        {
            var reg = new Regex(@"^[\w\-]+$");
            if (organizationSlug.Length > 50 || organizationSlug.Length < 3 || !reg.IsMatch(organizationSlug))
            {
                return false;
            }

            return !(await _context.Organizations.ToListAsync()).Any(o => o.OrganizationSlug == organizationSlug);
        }
    }
}
