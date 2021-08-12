using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Member;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class MemberService : BaseService, IMemberService
    {
        public MemberService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ICollection<MemberDto>> GetMembersByOrganizationIdAsync(int id)
        {
            return _mapper.Map<ICollection<MemberDto>>(await _context.Members.Where(m => m.OrganizationId == id).Include(m => m.User).ToListAsync());
        }

        public async Task<ICollection<MemberDto>> GetAllMembersAsync()
        {
            var members = await _context.Members.ToListAsync();
            return _mapper.Map<ICollection<MemberDto>>(members);
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            var member = await _context.Members.Include(m => m.User).FirstOrDefaultAsync(m => m.Id == id) ?? throw new KeyNotFoundException("Member doesn't exist");
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<ICollection<MemberDto>> SearchMembersNotInTeamAsync(int teamId, string memberEmail)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == teamId);

            var members = await _context.Members
                .Include(m => m.User)
                .Where(m => m.User.Email.Contains(memberEmail) && !m.TeamMembers.Any(t => t.TeamId == teamId) && m.OrganizationId == team.OrganizationId)
                .ToListAsync();
            return _mapper.Map<ICollection<MemberDto>>(members);
        }
        
        public async Task<MemberDto> CreateMemberAsync(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);

            var createdMember = _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return _mapper.Map<MemberDto>(createdMember.Entity);
        }
    }
}

