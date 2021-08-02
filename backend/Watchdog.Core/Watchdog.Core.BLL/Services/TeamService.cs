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
        
        public async Task<ICollection<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _context.Teams
                .Include(t => t.User)
                .Include(t => t.Organization)
                .Include(t => t.TeamMembers)
                    .ThenInclude(tm => tm.Member)
                    .ThenInclude(m => m.User)
                .ToListAsync();
            
            return _mapper.Map<ICollection<TeamDto>>(teams);
        }

        public async Task<TeamDto> GetTeamAsync(int teamId)
        {
            var teamEntity = await _context.Teams
                .Include(team => team.User)
                .Include(team => team.Organization)
                .Include(team => team.TeamMembers)
                    .ThenInclude(teamMember => teamMember.Member)
                    .ThenInclude(member => member.User)
                .FirstOrDefaultAsync(team => team.Id == teamId);
            
            return _mapper.Map<TeamDto>(teamEntity);
        }

        public async Task<ICollection<TeamDto>> GetUserTeamsAsync(int userId)
        {
            var teams = await _context.Teams
                .Include(team => team.User)
                .Include(team => team.Organization)
                .Include(team => team.TeamMembers)
                    .ThenInclude(teamMember => teamMember.Member)
                    .ThenInclude(member => member.User)
                .Where(team => team.CreatedBy == userId)
                .ToListAsync();
            
            return _mapper.Map<ICollection<TeamDto>>(teams);
        }

        public async Task<TeamDto> CreateTeamAsync(NewTeamDto newTeam)
        {
            var team = _mapper.Map<Team>(newTeam, opts => opts.AfterMap((src, dst) =>
            {
                dst.CreatedAt = DateTime.Now;
            }));

            var createdTeam = _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<TeamDto>(await GetTeamAsync(createdTeam.Entity.Id));
        }
        
        public async Task<TeamDto> UpdateTeamAsync(int teamId, UpdateTeamDto updateTeam)
        {
            var existedTeam = await _context.Teams.FirstAsync(t => t.Id == teamId);
            
            var mergedTeam = _mapper.Map(updateTeam, existedTeam);

            var updatedTeam= _context.Update(mergedTeam);
            await _context.SaveChangesAsync();

            return _mapper.Map<TeamDto>(await GetTeamAsync(updatedTeam.Entity.Id));
        }
            
        public async Task DeleteTeamAsync(int teamId)
        {
            var team = await _context.Teams.FirstAsync(t => t.Id == teamId);
            _context.Remove(team);

            await _context.SaveChangesAsync();
        }
    }
}