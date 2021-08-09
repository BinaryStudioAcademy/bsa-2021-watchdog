using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Member;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService service)
        {
            _memberService = service;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAllMembers(int organizationId)
        {
            var members = await _memberService.GetMembersByOrganizationIdAsync(organizationId);
            return Ok(members);
        }

        [HttpGet("team/{teamId}/exceptTeam/")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetMembersExceptTeam(int teamId, string memberEmail = "")
        {
            var members = await _memberService.SearchMembersNotInTeamAsync(teamId, memberEmail);
            return Ok(members);
        }
    }
}
