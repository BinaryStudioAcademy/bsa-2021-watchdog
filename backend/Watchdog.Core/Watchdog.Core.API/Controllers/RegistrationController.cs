using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Registration;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("full")]
        public async Task<ActionResult<UserDto>> FullRegistrationAsync(FullRegistrationDto registrationDto)
        {
            var user = await _registrationService.FullRegistrationAsync(registrationDto);
            return Ok(user);
        }

        [HttpPost("partial")]
        public async Task<ActionResult<UserDto>> PartialRegistrationAsync(PartialRegistrationDto registrationDto)
        {
            var user = await _registrationService.PartialRegistrationAsync(registrationDto);
            return Ok(user);
        }
    }
}
