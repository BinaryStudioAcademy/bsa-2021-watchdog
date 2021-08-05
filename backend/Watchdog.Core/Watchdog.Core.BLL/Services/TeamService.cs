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
                .Include(team => team.Members)
                    .ThenInclude(member => member.User)
                .Where(t => t.OrganizationId == organizationId)
                .ToListAsync();
            
            return _mapper.Map<ICollection<TeamDto>>(teams);
        }

        public async Task<ICollection<TeamDto>> GetMemberTeamsAsync(int organizationId, int memberId, bool isForMemberInTeam)
        {
            var memberTeams = await _context.Teams
                .Include(team => team.Members)
                    .ThenInclude(member => member.User)
                .Where(t => t.OrganizationId == organizationId)
                .Where(t => isForMemberInTeam ? 
                        t.Members.Any(tm => tm.Id == memberId) : 
                        t.Members.All(tm => tm.Id != memberId))
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
            var member = await _context.Members.FindAsync(teamMemberDto.MemberId) ?? throw new KeyNotFoundException("Member was not found");
            member.TeamId = teamMemberDto.TeamId;
            await _context.SaveChangesAsync();
            return await GetTeamAsync(member.TeamId);
        }
        
        public async Task<TeamDto> LeaveTeamAsync(int teamId, int memberId)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == memberId && m.TeamId == teamId);
            _context.Members.Remove(member);
            
            await _context.SaveChangesAsync();
            
            return await GetTeamAsync(teamId);
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
                .Include(teamMember => teamMember.Members)
                .ThenInclude(teamMember => teamMember.User)
                .FirstOrDefaultAsync(team => team.Id == teamId);
            
            return _mapper.Map<TeamDto>(teamEntity);
        }
    }
}