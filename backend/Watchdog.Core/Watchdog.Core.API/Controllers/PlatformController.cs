using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Platform;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformDto>>> GetAllPlatforms()
        {
            return Ok(await _platformService.GetAllPlatformsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllPlatformTypes()
        {
            return Ok(await _platformService.GetAllPlatformTypeNames());
        }
    }
}
