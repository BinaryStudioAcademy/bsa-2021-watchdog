using SendGrid;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IMemberService
    {
        Task<MemberDto> GetMemberByIdAsync(int id);

        Task<IEnumerable<MemberDto>> GetMembersByOrganizationIdAsync(int id);

        Task<MemberDto> AddMemberAsync(NewMemberDto member);

        Task<MemberDto> UpdateMemberAsync(UpdateMemberDto member);

        Task DeleteMemberAsync(int id);
        Task<Response> InviteMember(MemberDto memberDto);
    }
}
