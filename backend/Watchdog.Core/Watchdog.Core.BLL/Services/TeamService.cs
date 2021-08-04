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
        
        public async Task<ICollection<TeamDto>> GetAllTeamsAsync(int organizationId)
        {
            var teams = await _context.Teams
                .Include(team => team.TeamMembers)
                    .ThenInclude(teamMember => teamMember.Member)
                    .ThenInclude(teamMember => teamMember.User)
                .Where(t => t.OrganizationId == organizationId)
                .ToListAsync();
            
            return _mapper.Map<ICollection<TeamDto>>(teams);
        }

        public async Task<ICollection<TeamDto>> GetMemberTeamsAsync(int organizationId, int memberId, bool isForMemberInTeam)
        {
            var memberTeams = await _context.Teams
                .Include(team => team.TeamMembers)
                    .ThenInclude(teamMember => teamMember.Member)
                    .ThenInclude(teamMember => teamMember.User)
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
                dst.CreatedAt = DateTime.Now;
            }));
            
            var createdTeam = _context.Teams.Add(team).Entity;
            
            await _context.SaveChangesAsync();
            
            var createdTeamDto = await AddMemberToTeamAsync(new TeamMemberDto()
            {
                TeamId = createdTeam.Id,
                MemberId = newTeam.CreatedBy
            });
            
            return createdTeamDto;
        }
        
        public async Task<TeamDto> UpdateTeamAsync(int teamId, UpdateTeamDto updateTeam)
        {
            var existedTeam = await _context.Teams.FirstAsync(t => t.Id == teamId);
            
            var mergedTeam = _mapper.Map(updateTeam, existedTeam);

            var updatedTeam= _context.Update(mergedTeam);
            await _context.SaveChangesAsync();

            return await GetTeamAsync(updatedTeam.Entity.Id);
        }
        
        public async Task<TeamDto> AddMemberToTeamAsync(TeamMemberDto teamMemberDto)
        {
            var teamMember = _mapper.Map<TeamMember>(teamMemberDto);
            
            var created = _context.TeamMembers.Add(teamMember).Entity;
            await _context.SaveChangesAsync();
            
            return await GetTeamAsync(created.TeamId);
        }
        
        public async Task<TeamDto> LeaveTeamAsync(int teamId, int memberId)
        {
            var teamMember = await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.MemberId == memberId && tm.TeamId == teamId);
            
            _context.Remove(teamMember);
            
            await _context.SaveChangesAsync();
            
            return await GetTeamAsync(teamMember.TeamId); 
        }
        
        public async Task DeleteTeamAsync(int teamId)
        {
            var team = await _context.Teams.FirstAsync(t => t.Id == teamId);
            _context.Remove(team);
            
            await _context.SaveChangesAsync();
        }
        
        private async Task<TeamDto> GetTeamAsync(int teamId)
        {
            var teamEntity = await _context.Teams
                .Include(team => team.TeamMembers)
                    .ThenInclude(teamMember => teamMember.Member)
                    .ThenInclude(teamMember => teamMember.User)
                .FirstOrDefaultAsync(team => team.Id == teamId);
            
            return _mapper.Map<TeamDto>(teamEntity);
        }
    }
}