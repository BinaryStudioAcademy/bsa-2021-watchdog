﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Member;

namespace Watchdog.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly ILogger<SampleController> _logger;
        private readonly IMemberService _memberService;

        public MembersController(ILogger<SampleController> logger,
                                 IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<MemberDto>>> GetAllAsync()
        {
            var members = await _memberService.GetAllMembersAsync();
            return Ok(members);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MemberDto>> GetByIdAsync(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> CreateMemberAsync(MemberDto memberDto)
        {
            var member = await _memberService.CreateMemberAsync(memberDto);
            return Ok(member);
        }
    }
}
