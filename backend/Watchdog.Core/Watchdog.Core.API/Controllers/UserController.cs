using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
                              IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{uid}")]
        public async Task<ActionResult<UserDto>> GetUser(string uid)
        {
            var user = await _userService.GetUserByUidAsync(uid);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateAsync(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userService.CreateUserAsync(userDto);
            return Ok(user);
        }
    }
}
