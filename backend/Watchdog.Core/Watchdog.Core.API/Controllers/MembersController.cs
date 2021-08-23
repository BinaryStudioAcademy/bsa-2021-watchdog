using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
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

        [HttpPost("organization/{organizationId}")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAllMembers([FromRoute] int organizationId, [FromBody] FilterModel filterPayload)
        {
            var (members, totalRecord) = await _memberService.GetMembersByOrganizationIdLazyAsync(organizationId, filterPayload);
            return Ok(new { Collection = members, TotalRecord = totalRecord });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            return Ok(member);
        }

        [HttpPut]
        public async Task<ActionResult<MemberDto>> Update(UpdateMemberDto dto)
        {
            var member = await _memberService.UpdateAsync(dto);
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<InvitedMemberDto>> AddMember(NewMemberDto newMemberDto)
        {
            var invitedMember = await _memberService.AddAndInviteMember(newMemberDto);
            return Ok(invitedMember);
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

        [HttpPost("reinvite")]
        public async Task<ActionResult<int>> Reinvite(InviteDto dto)
        {
            var response = await _memberService.InviteMemberAsync(dto.Id);
            return Ok(response.StatusCode);
        }

        [HttpPost("acceptInvite")]
        public async Task<ActionResult<int>> AcceptInvite(InviteDto dto)
        {
            await _memberService.AcceptInviteAsync(dto.Id);
            return Ok();
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
