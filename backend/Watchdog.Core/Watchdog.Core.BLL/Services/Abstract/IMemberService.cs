using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Member;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IMemberService
    {
        Task<ICollection<MemberDto>> GetAllMembersAsync();
        Task<MemberDto> GetMemberByIdAsync(int id);
        Task<MemberDto> CreateMemberAsync(MemberDto memberDto);
    }
}
