using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Extensions;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Members;
using Watchdog.Core.Common.DTO.Role;
using Watchdog.Core.Common.DTO.Team;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Emailer;
using Watchdog.Models.Shared.Emailer.TemplateData;

namespace Watchdog.Core.BLL.Services
{

    public class MemberService : BaseService, IMemberService
    {
        private readonly IEmailerQueueProducerService _emailer;

        public MemberService(IMapper mapper,
                             IEmailerQueueProducerService emailer,
                             WatchdogCoreContext context)
            : base(context, mapper)
        {
            _emailer = emailer;
        }

        public async Task InviteMemberAsync(int id)
        {
            var member = await _context.Members
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id) ?? throw new KeyNotFoundException("Member doesn't exist");

            await InviteMemberAsync(_mapper.Map<MemberDto>(member));
        }

        public Task InviteMemberAsync(MemberDto memberDto)
        {
            var template = _mapper.Map<MemberTemplate>(memberDto);
            var recipients = new Recipient[]
            {
                _mapper.Map<Recipient>(memberDto)
            };
            _emailer.SendMemberInvitation(template, recipients);
            return Task.CompletedTask;
        }

        public async Task<MemberDto> AddMemberAsync(NewMemberDto memberDto)
        {
            var user = (await _context.Users.FirstOrDefaultAsync(u => u.Id == memberDto.UserId)) ?? throw new KeyNotFoundException("User doesn't exist");
            var organization = await _context.Organizations
                .Include(o => o.Members)
                .FirstOrDefaultAsync(o => o.Id == memberDto.OrganizationId)
                    ?? throw new KeyNotFoundException("Such organization doesn't exist");

            if (organization.Members.Any(m => m.UserId == user.Id))
            {
                throw new ArgumentException("This user already in organization");
            }

            var member = _mapper.Map<Member>(memberDto);

            foreach (int teamId in memberDto.TeamIds)
            {
                member.TeamMembers.Add(new TeamMember { TeamId = teamId });
            }

            member.IsApproved = true;

            await _context.Members.AddAsync(member);

            await _context.SaveChangesAsync();

            return await GetMemberByIdAsync(member.Id);
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await _context.Members.Include(m => m.TeamMembers)
                .FirstOrDefaultAsync(m => (m.Id == id) && (m.Role.Name != "Owner")) ?? throw new InvalidOperationException("You cannot delete this member");
            _context.Members.Remove(member);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<MemberDto>> GetMembersByOrganizationIdAsync(int id)
        {
            var members = await _context.Members.Where(m => m.OrganizationId == id)
                .Include(m => m.User)
                .Include(m => m.TeamMembers)
                    .ThenInclude(tm => tm.Team)
                .Include(m => m.Role)
                .ToListAsync();
            return _mapper.Map<ICollection<MemberDto>>(members);

        }

        public async Task<ICollection<MemberDto>> GetMembersForAssigneeByOrganizationIdAsync(int id)
        {
            return await GetMembersByOrganizationIdAsync(id);
        }


        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            var member = await _context.Members
                .Include(m => m.User)
                .Include(m => m.TeamMembers)
                    .ThenInclude(tm => tm.Team)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id) ?? throw new KeyNotFoundException("Member doesn't exist");
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<ICollection<MemberDto>> SearchMembersNotInTeamAsync(int teamId, int count, string memberEmail)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == teamId);

            var members = await _context.Members
                .Include(m => m.TeamMembers)
                .Include(m => m.User)
                .Where(m => m.User.Email.Contains(memberEmail) && !m.TeamMembers.Any(t => t.TeamId == teamId) && m.OrganizationId == team.OrganizationId)
                .Take(count)
                .ToListAsync();
            return _mapper.Map<ICollection<MemberDto>>(members);
        }

        public async Task<IEnumerable<MemberDto>> GetInvitedMembers()
        {
            return _mapper.Map<IEnumerable<MemberDto>>(await _context.Members.Where(m => !m.IsAccepted).ToListAsync());
        }

        public async Task<ICollection<MemberDto>> GetAllMembersAsync()
        {
            var members = await _context.Members
                .Include(m => m.User)
                .Include(m => m.TeamMembers)
                    .ThenInclude(tm => tm.Team)
                .Include(m => m.Role)
                .ToListAsync();
            return _mapper.Map<ICollection<MemberDto>>(members);
        }

        public async Task<MemberDto> GetMemberByUserIdAndOrganizationIdAsync(int userId, int orgId)
        {
            var ogranization = await _context.Organizations
                .Include(o => o.Members)
                .ThenInclude(m => m.User)
                .FirstOrDefaultAsync(o => o.Id == orgId)
                ?? throw new KeyNotFoundException("Organization doesn't exist");

            var member = ogranization.Members.FirstOrDefault(m => m.User.Id == userId)
                ?? throw new KeyNotFoundException("Member doesn't exist in organization");

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> UpdateAsync(UpdateMemberDto dto)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == dto.Id)
                ?? throw new KeyNotFoundException("Member doesn't exists");
            member.RoleId = dto.RoleId;
            await _context.SaveChangesAsync();
            return _mapper.Map<MemberDto>(member);
        }

        public async Task AcceptInviteAsync(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id) ?? throw new KeyNotFoundException("Member doesn't exist");

            member.IsAccepted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<MemberDto> ApproveUserAsync(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id)
                ?? throw new KeyNotFoundException("Member doesn't exist");
            member.IsAccepted = true;
            member.IsApproved = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<InvitedMemberDto> AddInvitedMemberAsync(NewMemberDto memberDto)
        {
            var member = await AddMemberAsync(memberDto);
            await InviteMemberAsync(member);
            return new InvitedMemberDto { Member = member };
        }

        public async Task<bool> IsMemberOwnerAsync(int memberId)
        {
            var member = await _context.Members
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.Id == memberId) ?? throw new KeyNotFoundException("Member doesn't exists");

            return member.Role.Name.ToLower() == "owner";
        }

        public async Task<(ICollection<MemberDto>, int)> GetMembersByOrganizationIdLazyAsync(int id, FilterModel filterPayload)
        {
            var members = await _context.Members.Where(m => m.OrganizationId == id)
                .Include(m => m.User)
                .Include(m => m.TeamMembers)
                    .ThenInclude(tm => tm.Team)
                .Include(m => m.Role)
                .Select(m => new MemberDto
                {
                    Id = m.Id,
                    IsAccepted = m.IsAccepted,
                    IsApproved = m.IsApproved,
                    OrganizationId = m.OrganizationId,
                    Role = _mapper.Map<RoleDto>(m.Role),
                    RoleId = m.RoleId,
                    RoleName = m.Role.Name,
                    Teams = _mapper.Map<IEnumerable<TeamOptionDto>>(m.TeamMembers.Select(tm => tm.Team)),
                    User = _mapper.Map<UserDto>(m.User),
                    UserEmail = m.User.Email,
                    UserFirstName = m.User.FirstName,
                    UserLastName = m.User.LastName
                })
                .Filter(filterPayload, out var totalRecord)
                .ToListAsync();
            return (members, totalRecord);
        }

        public async Task<ICollection<int>> GetMembersIdsByApplicationUid(string applicationUid)
        {
            var memberIds = await _context.TeamMembers
                .Where(tm => tm.Team.ApplicationTeams.Any(at => at.Application.ApiKey == applicationUid))
                .Select(tm => tm.MemberId)
                .Distinct()
                .ToListAsync();

            return memberIds;
        }
    }
}