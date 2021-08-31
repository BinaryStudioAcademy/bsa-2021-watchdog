using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        
        [AllowAnonymous]
        [HttpGet("{uid}")]
        public async Task<ActionResult<UserDto>> GetUser(string uid)
        {
            var user = await _userService.GetUserByUidAsync(uid);
            return Ok(user);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync(NewUserDto userDto)
        {
            var user = await _userService.CreateUserAsync(userDto);
            return Ok(user);
        }

        [HttpPut("{userId:int}")]
        public async Task<ActionResult<UserDto>> UpdateAsync(int userId, UpdateUserDto updateUserDto)
        {
            var user = await _userService.UpdateUserAsync(userId, updateUserDto);
            return Ok(user);
        }

        [HttpGet("organization/{orgId:int}/notInOrg/")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetMembersNotInOrganization(int orgId, int count, string memberEmail = "")
        {
            var members = await _userService.SearchMembersNotInOrganizationAsync(orgId, count, memberEmail);
            return Ok(members);
        }
        
        [AllowAnonymous]
        [HttpGet("email/{userEmail}")]
        public async Task<ActionResult<bool>> IsEmailValid(string userEmail)
        {
            return Ok(await _userService.IsUserEmailValid(userEmail));
        }
    }
}
