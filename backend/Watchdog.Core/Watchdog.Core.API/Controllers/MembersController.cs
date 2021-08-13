using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAllMembers(int organizationId)
        {
            var members = await _memberService.GetMembersByOrganizationIdAsync(organizationId);
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult> AddMember(NewMemberDto newMemberDto)
        {
            MemberDto member;
            try
            {
                member = await _memberService.AddMemberAsync(newMemberDto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { ex.Message });
            }
            var response = await _memberService.InviteMember(member);
            return Ok(new { Member = member, SendMailResponse = response });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(int id)
        {
            await _memberService.DeleteMemberAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAllAsync()
        {
            var members = await _memberService.GetAllMembersAsync();
            return Ok(members);
        }


        [HttpGet("team/{teamId}/exceptTeam/")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetMembersExceptTeam(int teamId, string memberEmail = "")
        {
            var members = await _memberService.SearchMembersNotInTeamAsync(teamId, memberEmail);
            return Ok(members);
        }

        [HttpGet("organization/{orgId}/user/{userId}")]
        public async Task<ActionResult<MemberDto>> GetMemberByUserAndOrganization(int userId, int orgId)
        {
            return Ok(await _memberService.GetMemberByUserIdAndOrganizationIdAsync(userId, orgId));
        }
    }
}
