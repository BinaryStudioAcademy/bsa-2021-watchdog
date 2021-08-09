using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserDto>>> GetAllAsync()
        {
            var user = await _userService.GetAllUsersAsync();
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetAsync(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDto>> UpdateAsync(int userId, UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userService.UpdateUserAsync(userId, updateUserDto);
            return Ok(user);
        }

    }
}
