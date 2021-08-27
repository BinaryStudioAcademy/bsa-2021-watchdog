using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.ApplicationTeam;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class ApplicationService : BaseService, IApplicationService
    {
        public ApplicationService(WatchdogCoreContext context, IMapper mapper)
            : base(context, mapper) { }

        public async Task<ApplicationTeamDto> AddAppTeamAsync(NewApplicationTeamDto appTeam)
        {
            var mappedAppTeam = _mapper.Map<ApplicationTeam>(appTeam);

            var existingAppTeam = await _context.ApplicationTeams
                .FirstOrDefaultAsync(t => t.ApplicationId == mappedAppTeam.ApplicationId && t.TeamId == mappedAppTeam.TeamId);

            if (existingAppTeam != null) throw new InvalidOperationException("This application already exists in this team!");

            var addedAppTeam = await _context.ApplicationTeams.AddAsync(mappedAppTeam);
            await _context.SaveChangesAsync();
            await addedAppTeam.Reference(at => at.Application).LoadAsync();

            return _mapper.Map<ApplicationTeamDto>(addedAppTeam.Entity);
        }

        public async Task<bool> UpdateFavoriteStateAsync(int appTeamId, bool state)
        {
            var appTeam = await _context.ApplicationTeams.FirstAsync(s => s.Id == appTeamId);

            appTeam.IsFavorite = state;
            _context.ApplicationTeams.Update(appTeam);

            await _context.SaveChangesAsync();

            return appTeam.IsFavorite;
        }

        public async Task<ICollection<ApplicationDto>> GetAppsByOrganizationIdAsync(int organizationId)
        {
            var applications = await _context.Applications
                .Include(a => a.Platform)
                .Where(a => a.OrganizationId == organizationId)
                .ToListAsync();
            return _mapper.Map<ICollection<ApplicationDto>>(applications);
        }

        public async Task<ICollection<ApplicationTeamDto>> GetAppsByTeamIdAsync(int teamId)
        {
            var applicationTeams = await _context.ApplicationTeams
                .Where(a => a.TeamId == teamId)
                .Include(a => a.Team)
                .Include(a => a.Application)
                .ToListAsync();
            return _mapper.Map<ICollection<ApplicationTeamDto>>(applicationTeams);
        }

        public async Task<ICollection<ApplicationDto>> SearchAppsNotInTeamAsync(int teamId, string teamName)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == teamId);

            var applications = await _context.Applications
                .Include(a => a.ApplicationTeams)
                .Include(a => a.Platform)
                .Where(a => a.OrganizationId == team.OrganizationId
                        && a.ApplicationTeams.All(t => t.TeamId != teamId)
                        && a.Name.Contains(teamName))
                .ToListAsync();
            return _mapper.Map<ICollection<ApplicationDto>>(applications);
        }

        public async Task RemoveAppTeam(int appTeamId)
        {
            var appTeam = await _context.ApplicationTeams.FirstOrDefaultAsync(t => t.Id == appTeamId)
                ?? throw new InvalidOperationException("Application in this team not found!");

            _context.ApplicationTeams.Remove(appTeam);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationDto> CreateAppAsync(NewApplicationDto dto)
        {
            var application = _mapper.Map<Application>(dto);

            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == dto.TeamId) ??
                       throw new KeyNotFoundException("No team with this id!");

            await _context.AddAsync(application);

            application.ApplicationTeams.Add(new ApplicationTeam
            {
                Team = team,
                Application = application
            });
            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(int appId)
        {
            var application = await _context.Applications
                .Include(p => p.Platform)
                .FirstOrDefaultAsync(a => a.Id == appId) ??
                throw new InvalidOperationException("No application with this id!");

            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto> UpdateApplicationAsync(int appId, UpdateApplicationDto updateAppDto)
        {
            if (_context.Applications.Any(app => app.ApiKey == updateAppDto.ApiKey && app.Id != appId))
            {
                throw new InvalidOperationException("There are already exists application with such id.");
            }

            var existedApplication = await _context.Applications.FirstOrDefaultAsync(a => a.Id == appId) ??
                throw new InvalidOperationException("No application with this id!");

            var mergedApplication = _mapper.Map(updateAppDto, existedApplication);

            var updateApplication = _context.Update(mergedApplication);
            await _context.SaveChangesAsync();

            return await GetApplicationByIdAsync(updateApplication.Entity.Id);
        }

        public async Task DeleteApplicationAsync(int appId)
        {
            var application = await _context.Applications
                .Include(t => t.ApplicationTeams)
                .FirstOrDefaultAsync(a => a.Id == appId) ??
                throw new InvalidOperationException("No application with this id!");
            _context.Remove(application);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsProjectNameValidAsync(string projectName, int organizationId)
        {
            if (projectName.Length < 3 || projectName.Length > 50)
            {
                return false;
            }

            return !(await _context.Applications
                .Where(a => a.OrganizationId == organizationId)
                .AnyAsync(a => a.Name == projectName));
        }

        public async Task<bool> IsApiKeyUniqueAsync(string apiKey)
        {
            var reg = new Regex(@"^[0-9A-Za-z-_]+$");

            if (apiKey.Length != 36 && !reg.IsMatch(apiKey))
            {
                return false;
            }

            return await _context.Applications.AllAsync(app => app.ApiKey != apiKey);
        }

        public AppKeys GenerateApiKeyAsync() => new() { ApiKey = Guid.NewGuid().ToString().ToUpper() };

        public async Task<ICollection<ApplicationDto>> GetAppsByMemberIdAsync(int memberId)
        {
            var member = await _context.Members
                .Include(m => m.TeamMembers)
                    .ThenInclude(tm => tm.Team)
                        .ThenInclude(t => t.ApplicationTeams)
                            .ThenInclude(at => at.Application)
                .FirstOrDefaultAsync(m => m.Id == memberId) ?? throw new KeyNotFoundException("No member with such id!");

            var apps = member.TeamMembers.SelectMany(tm => tm.Team.ApplicationTeams).Select(at => at.Application).Distinct();

            return _mapper.Map<ICollection<ApplicationDto>>(apps);
        }
    }
}
