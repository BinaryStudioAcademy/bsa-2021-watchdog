using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPut("user")]
        public async Task<ActionResult<UserDto>> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            _logger.LogInformation(1002, $"Update user");
            //var updateUser = await _userService.UpdateUserAsync(userId, updateUserDto);
            //return Ok(updateUser);
            return Ok(await _userService.UpdateUserAsync(updateUserDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            _logger.LogInformation(1002, $"Get user by id {userId}");
            return Ok(await _userService.GetUserAsync(userId));
        }

    }
}
