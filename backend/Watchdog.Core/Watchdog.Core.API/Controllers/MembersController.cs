using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("organization/{organizationId:int}")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAllMembers(int organizationId)
        {
            var members = await _memberService.GetMembersByOrganizationIdAsync(organizationId);
            return Ok(members);
        }

        [HttpPost("organization/{organizationId:int}")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAllMembers([FromRoute] int organizationId, [FromBody] FilterModel filterPayload)
        {
            var (members, totalRecord) = await _memberService.GetMembersByOrganizationIdLazyAsync(organizationId, filterPayload);
            return Ok(new { Collection = members, TotalRecord = totalRecord });
        }

        [HttpGet("{id:int}")]
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
            var invitedMember = await _memberService.AddInvitedMemberAsync(newMemberDto);
            return Ok(invitedMember);
        }


        [HttpDelete("{id:int}")]
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
            await _memberService.InviteMemberAsync(dto.Id);
            return Ok();
        }

        [HttpPost("acceptInvite")]
        public async Task<ActionResult<int>> AcceptInvite(InviteDto dto)
        {
            await _memberService.AcceptInviteAsync(dto.Id);
            return Ok();
        }

        [HttpPost("approveUser")]
        public async Task<ActionResult<MemberDto>> ApproveUser(InviteDto dto)
        {
            var member = await _memberService.ApproveUserAsync(dto.Id);
            return Ok(member);
        }

        [HttpGet("team/{teamId:int}/exceptTeam/")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetMembersExceptTeam(int teamId, int count, string memberEmail = "")
        {
            var members = await _memberService.SearchMembersNotInTeamAsync(teamId, count, memberEmail);
            return Ok(members);
        }

        [HttpGet("organization/{orgId:int}/user/{userId:int}")]
        public async Task<ActionResult<MemberDto>> GetMemberByUserAndOrganization(int userId, int orgId)
        {
            return Ok(await _memberService.GetMemberByUserIdAndOrganizationIdAsync(userId, orgId));
        }

        [HttpGet("isowner/{memberId:int}")]
        public async Task<ActionResult<bool>> IsMemberOwner(int memberId)
        {
            return Ok(await _memberService.IsMemberOwnerAsync(memberId));
        }

        [HttpGet("organization/{orgId:int}/assignee")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAssigneeByOrganization(int orgId)
        {
            return Ok(await _memberService.GetMembersForAssigneeByOrganizationIdAsync(orgId));
        }
    }
}
