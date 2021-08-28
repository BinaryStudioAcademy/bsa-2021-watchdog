using SendGrid;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IMemberService
    {
        Task<MemberDto> GetMemberByIdAsync(int id);
        Task<ICollection<MemberDto>> GetMembersByOrganizationIdAsync(int id);

        Task<(ICollection<MemberDto>, int)> GetMembersByOrganizationIdLazyAsync(int id, FilterModel filterPayload);

        Task<ICollection<MemberDto>> SearchMembersNotInTeamAsync(int teamId, int count, string memberEmail);

        Task<ICollection<MemberDto>> GetAllMembersAsync();

        Task<MemberDto> AddMemberAsync(NewMemberDto memberDto);

        Task<InvitedMemberDto> AddInvitedMemberAsync(NewMemberDto memberDto);

        Task DeleteMemberAsync(int id);
        Task<Response> InviteMemberAsync(MemberDto memberDto);
        Task<Response> InviteMemberAsync(int id);
        Task<MemberDto> GetMemberByUserIdAndOrganizationIdAsync(int userId, int orgId);
        Task<MemberDto> UpdateAsync(UpdateMemberDto dto);
        Task AcceptInviteAsync(int id);
        Task<bool> IsMemberOwnerAsync(int id);
    }
}
