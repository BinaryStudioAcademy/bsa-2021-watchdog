using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Members;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class MemberService : BaseService, IMemberService
    {
        private readonly IEmailSendService _emailSendService;

        public MemberService(WatchdogCoreContext context, IMapper mapper, IEmailSendService emailSendService) : base(context, mapper)
        {
            _emailSendService = emailSendService;
        }

        public Task<Response> InviteMember(MemberDto memberDto)
        {
            ExampleTemplateData data = new()
            {
                Name = memberDto.User.FirstName,
                Subject = "Invitation letter"
            };
            return _emailSendService.SendAsync(memberDto.User.Email, data);
        }

        public async Task<MemberDto> AddMemberAsync(NewMemberDto memberDto)
        {
            var user = (await _context.Users.FirstOrDefaultAsync(u => u.Email == memberDto.Email)) ?? throw new KeyNotFoundException("User doesn't exist");

            if (await _context.Members.FirstOrDefaultAsync(m => m.OrganizationId == memberDto.OrganizationId && m.TeamId == memberDto.TeamId) is not null)
            {
                throw new InvalidOperationException("Such member already in the team");
            }

            var member = _mapper.Map<Member>(memberDto);

            member.User = user;

            await _context.Members.AddAsync(member);

            await _context.SaveChangesAsync();

            return _mapper.Map<MemberDto>(member);
        }

        public async Task DeleteMemberAsync(int id)
        {
            var result = await _context.Members.FindAsync(id) ?? throw new KeyNotFoundException("Member doesn't exist");
            _context.Members.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersByOrganizationIdAsync(int id)
        {
            return _mapper.Map<IEnumerable<MemberDto>>(await _context.Members.Where(m => m.OrganizationId == id).Include(m => m.User).Include(m => m.Team).Include(m => m.Role).ToListAsync());

        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            var member = await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m => m.Id == id) ?? throw new KeyNotFoundException("Member doesn't exist");
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> UpdateMemberAsync(UpdateMemberDto member)
        {
            var result = await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m => m.Id == member.Id) ?? throw new KeyNotFoundException("Member doesn't exist");
            _context.Entry(result).CurrentValues.SetValues(member);

            await _context.SaveChangesAsync();
            return _mapper.Map<MemberDto>(result);
        }

        public async Task<IEnumerable<MemberDto>> SearchMembersNotInOrganizationAsync(int orgId, string memberEmail)
        {
            var members = await _context.Members
                .Include(m => m.User)
                .Where(m => m.User.Email.Contains(memberEmail) && m.OrganizationId != orgId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }
    }
}
        //    var member = await _context.Members.SingleOrDefaultAsync(m => m.Id == id);
        //    return _mapper.Map<MemberDto>(member);
        //}

        //public async Task<MemberDto> CreateMemberAsync(MemberDto memberDto)
        //{
        //    var member = _mapper.Map<Member>(memberDto);

        //    var createdMember = _context.Members.Add(member);
        //    await _context.SaveChangesAsync();

        //    return _mapper.Map<MemberDto>(createdMember.Entity);
        //}
