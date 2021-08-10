using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<ICollection<MemberDto>> GetAllMembersAsync()
        {
            var members = await _context.Members.ToListAsync();
            return _mapper.Map<ICollection<MemberDto>>(members);
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            var member = await _context.Members.SingleOrDefaultAsync(m => m.Id == id);
            return _mapper.Map<MemberDto>(member);
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
