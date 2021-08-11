using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetApplicationsByOrganizationId(int organizationId)
        {
            return Ok(await _applicationService.GetApplicationsByApplicationIdAsync(organizationId));
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> Create(NewApplicationDto dto)
        {
            var application = await _applicationService.CreateApplicationAsync(dto);
            return Created($"/applications/{application.Id}", application);
        }
    }
}
