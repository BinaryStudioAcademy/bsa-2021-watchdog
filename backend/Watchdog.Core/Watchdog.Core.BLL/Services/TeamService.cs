using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Team;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class TeamService : BaseService, ITeamService
    {
        public TeamService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<TeamDto> GetTeamAsync(int teamId)
        {
            var teamEntity = await GetTeamsWithMembersAsQueryable()
                .FirstOrDefaultAsync(team => team.Id == teamId);

            return _mapper.Map<TeamDto>(teamEntity);
        }

        public async Task<ICollection<TeamDto>> GetAllTeamsAsync(int organizationId)
        {
            var teams = await GetTeamsWithMembersAsQueryable()
                .Where(t => t.OrganizationId == organizationId)
                .ToListAsync();

            return _mapper.Map<ICollection<TeamDto>>(teams);
        }

        public async Task<ICollection<TeamDto>> GetMemberTeamsAsync(int organizationId, int memberId, bool isForMemberInTeam)
        {
            var memberTeams = await GetTeamsWithMembersAsQueryable()
                .Where(t => t.OrganizationId == organizationId)
                .Where(t => isForMemberInTeam ?
                        t.TeamMembers.Any(tm => tm.MemberId == memberId) :
                        t.TeamMembers.All(tm => tm.MemberId != memberId))
                .ToListAsync();

            return _mapper.Map<ICollection<TeamDto>>(memberTeams);
        }

        public async Task<TeamDto> CreateTeamAsync(NewTeamDto newTeam)
        {
            var team = _mapper.Map<Team>(newTeam, opts => opts.AfterMap((src, dst) =>
            {
                dst.CreatedAt = DateTime.UtcNow;
            }));

            var member = await _context.Members
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.UserId == team.CreatedBy && m.OrganizationId == newTeam.OrganizationId);

            var createdTeam = _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            await AddMemberToTeamAsync(new TeamMemberDto
            {
                MemberId = member.Id,
                TeamId = createdTeam.Entity.Id
            });
            
            return _mapper.Map<TeamDto>(createdTeam.Entity);
        }

        public async Task<TeamDto> UpdateTeamAsync(int teamId, UpdateTeamDto updateTeam)
        {
            var existedTeam = await _context.Teams.FirstOrDefaultAsync(t => t.Id == teamId);

            var mergedTeam = _mapper.Map(updateTeam, existedTeam);

            var updatedTeam = _context.Update(mergedTeam);
            await _context.SaveChangesAsync();

            return await GetTeamAsync(updatedTeam.Entity.Id);
        }

        public async Task<TeamDto> AddMemberToTeamAsync(TeamMemberDto teamMemberDto)
        {
            var teamMember = _mapper.Map<TeamMember>(teamMemberDto);

            if (await _context.TeamMembers.AnyAsync(t => t.MemberId == teamMember.MemberId && t.TeamId == teamMember.TeamId))
                throw new InvalidOperationException("This member is already in team!");

            var created = _context.TeamMembers.Add(teamMember).Entity;
            await _context.SaveChangesAsync();

            return await GetTeamAsync(created.TeamId);
        }

        public async Task<TeamDto> LeaveTeamAsync(int teamId, int memberId)
        {
            var teamMember = await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.MemberId == memberId && tm.TeamId == teamId)
                    ?? throw new KeyNotFoundException("Team or member was not found");

            _context.Remove(teamMember);

            await _context.SaveChangesAsync();

            return await GetTeamAsync(teamMember.TeamId);
        }

        public async Task DeleteTeamAsync(int teamId)
        {
            var team = await _context.Teams
                .Include(t => t.ApplicationTeams)
                .Include(t => t.TeamMembers)
                .FirstOrDefaultAsync(t => t.Id == teamId)
                    ?? throw new KeyNotFoundException("Team was not found");
            _context.Remove(team);

            await _context.SaveChangesAsync();
        }

        private IQueryable<Team> GetTeamsWithMembersAsQueryable()
        {
            return _context.Teams
                .Include(team => team.TeamMembers)
                    .ThenInclude(tm => tm.Member)
                        .ThenInclude(m => m.User);
        }

        public async Task<bool> IsTeamNameUniqueAsync(int orgId, string teamName)
        {
            return !await _context.Teams.Where(t => t.OrganizationId == orgId).AnyAsync(t => t.Name == teamName);
        }

        public async Task<ICollection<TeamOptionDto>> GetTeamsOptionsByOrganizationIdAsync(int organizationId)
        {
            var teams = await _context.Teams
                .Where(t => t.OrganizationId == organizationId)
                .ToListAsync();

            return _mapper.Map<ICollection<TeamOptionDto>>(teams);
        }

        public async Task<ICollection<TeamDto>> GetTeamsForAssigneeByOrganizationIdAsync(int orgId)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(o => o.Id == orgId)
                ?? throw new KeyNotFoundException("No organization with this id!");

            if (organization.TrelloIntegration && !string.IsNullOrWhiteSpace(organization.TrelloToken))
            {
                var teams = await _context.Teams
                    .Include(t => t.TeamMembers)
                    .Where(m => m.OrganizationId == orgId && 
                        m.TeamMembers.Count > 0 && 
                        m.TeamMembers.All(tm => !string.IsNullOrWhiteSpace(tm.Member.User.TrelloUserId)))
                    .ToListAsync();

                return _mapper.Map<ICollection<TeamDto>>(teams);
            }

            return await GetAllTeamsAsync(orgId);
        }
    }
}