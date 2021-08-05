using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous] // ??
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly WatchdogCoreContext _context;

        public ApplicationController(WatchdogCoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProgects()
        {
            return Ok(_context.Platforms);
        }
    }
}
