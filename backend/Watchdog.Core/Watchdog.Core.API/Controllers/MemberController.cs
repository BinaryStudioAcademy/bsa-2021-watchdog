using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]// ??
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

        [HttpPut]
        public async Task<ActionResult<MemberDto>> UpdateMember(UpdateMemberDto updateMember)
        {
            return Ok(await _memberService.UpdateMemberAsync(updateMember));       
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(int id)
        {
            await _memberService.DeleteMemberAsync(id);
            return NoContent();
        }

        [HttpGet("organization/{orgId}/notInOrg/")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembersNotInOrganization(int orgId, string memberEmail = "")
        {
            var members = await _memberService.SearchMembersNotInOrganizationAsync(orgId, memberEmail);
            return Ok(members);
        }
    }
}
