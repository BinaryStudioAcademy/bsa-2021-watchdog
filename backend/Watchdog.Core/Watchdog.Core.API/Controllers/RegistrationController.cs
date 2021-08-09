using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Registration;

namespace Watchdog.Core.API.Controllers
{
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
        public async Task<ActionResult<DateTime>> FullRegistrationAsync(FullRegistrationDto registrationDto)
        {
            var registeredAt = await _registrationService.FullRegistrationAsync(registrationDto);
            return Ok(registeredAt);
        }

        [HttpPost("partial")]
        public async Task<ActionResult<DateTime>> PartialRegistrationAsync(PartialRegistrationDto registrationDto)
        {
            var registeredAt = await _registrationService.PartialRegistrationAsync(registrationDto);
            return Ok(registeredAt);
        }
    }
}
