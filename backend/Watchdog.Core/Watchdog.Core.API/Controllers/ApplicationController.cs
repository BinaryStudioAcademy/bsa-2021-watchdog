using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetApplicationsByOrganizationId(int organizationId)
        {
            return Ok(await _applicationService.GetApplicationsByApplicationId(organizationId));
        }
    }
}
