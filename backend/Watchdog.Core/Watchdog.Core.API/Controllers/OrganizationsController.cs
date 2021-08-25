﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Organization;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<OrganizationDto>>> GetAllAsync()
        {
            var organizations = await _organizationService.GetAllOrganizationsAsync();
            return Ok(organizations);
        }

        [HttpGet("slug/{organizationSlug}")]
        public async Task<ActionResult<bool>> IsSlugValid(string organizationSlug)
        {
            return Ok(await _organizationService.IsOrganizationSlugValid(organizationSlug));
        }

        [HttpGet("{organizationId}")]
        public async Task<ActionResult<OrganizationDto>> GetAsync(int organizationId)
        {
            var organization = await _organizationService.GetOrganizationAsync(organizationId);
            return Ok(organization);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ICollection<OrganizationDto>>> GetByUserAsync(int userId)
        {
            var organizations = await _organizationService.GetUserOrganizationsAsync(userId);
            return Ok(organizations);
        }

        [HttpPost]
        public async Task<ActionResult<OrganizationDto>> CreateOrganizationAsync(NewOrganizationDto organizationDto)
        {
            var organization = await _organizationService.CreateOrganizationAsync(organizationDto);
            return Ok(organization);
        }

        [HttpPut("{organizationId}")]
        public async Task<ActionResult<OrganizationDto>> UpdateAsync(int organizationId, NewOrganizationDto organizationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var organization = await _organizationService.UpdateOrganizationAsync(organizationId, organizationDto);
            return Ok(organization);
        }
        [HttpPut("settings/{organizationId}")]
        public async Task<ActionResult<OrganizationDto>> UpdateSettings(int organizationId, SettingsOrganizationDto settings)
        {
            var updatedOrganization = await _organizationService.UpdateSettingsAsync(organizationId, settings);
            return Ok(updatedOrganization);
        }

        [HttpGet("slug/join/{organizationJoinSlug}")]
        public async Task<ActionResult<bool>> IsJoinToOrganizationValid(string organizationJoinSlug)
        {
            return Ok(await _organizationService.IsOrganizationJoinValid(organizationJoinSlug));
        }
    }
}
