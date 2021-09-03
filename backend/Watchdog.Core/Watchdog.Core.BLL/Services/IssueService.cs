using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Extensions;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.DTO.IssueSolution;
using Watchdog.Core.Common.Enums.Issues;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Core.BLL.Services
{
    public class IssueService : BaseService, IIssueService
    {
        private readonly IElasticClient _client;

        public IssueService(WatchdogCoreContext context, IMapper mapper, IElasticClient client)
            : base(context, mapper)
        {
            _client = client;
        }

        public async Task<int> AddIssueEventAsync(IssueMessage issueMessage)
        {
            var issue = await _context.Issues.Include(i => i.Application)
                .FirstOrDefaultAsync(i =>
                  i.ErrorMessage == issueMessage.IssueDetails.ErrorMessage &&
                  i.ErrorClass == issueMessage.IssueDetails.ClassName &&
                  i.Application.ApiKey == issueMessage.ApiKey)
                ?? await CreateNewIssueAsync(issueMessage);

            if (issue.Status is IssueStatus.Resolved)
            {
                issue.Status = IssueStatus.Active;
            }

            var newEventMessage = _mapper.Map<EventMessage>(issueMessage);

            newEventMessage.IssueId = issue.Id;
            await _context.EventMessages.AddAsync(newEventMessage);

            issue.Newest = newEventMessage;
            issue.EventsCount++;
            await _context.SaveChangesAsync();

            return issue.Id;
        }

        public async Task<IssueDto> GetIssueByIdAsync(int issueId)
        {
            var issueEntity = await _context.Issues
                                  .AsNoTracking()
                                  .Include(issue => issue.Application)
                                  .FirstOrDefaultAsync(issue => issue.Id == issueId)
                              ?? throw new KeyNotFoundException("Issue not found");

            return _mapper.Map<IssueDto>(issueEntity);
        }

        public async Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync(int memberId, IssueStatus? status)
        {
            if (await _context.Members.AllAsync(m => m.Id != memberId))
            {
                throw new KeyNotFoundException("There is no member with such ID.");
            }
            return await GetIssuesAsQuerable(memberId, status)
                .Select(i => new IssueInfoDto
                {
                    IssueId = i.Id,
                    ErrorClass = i.ErrorClass,
                    ErrorMessage = i.ErrorMessage,
                    EventsCount = i.EventsCount,
                    Application = _mapper.Map<ApplicationDto>(i.Application),
                    Status = i.Status,
                    AffectedUsersCount = i.EventMessages
                        .Select(e => e.AffectedUserIdentifier)
                        .Where(t => !string.IsNullOrWhiteSpace(t))
                        .Distinct()
                        .Count(),
                    Newest = new IssueMessageDto()
                    {
                        Id = i.Newest.EventId,
                        OccurredOn = i.Newest.OccurredOn
                    },
                    Assignee = new AssigneeDto
                    {
                        MemberIds = _context.AssigneeMembers
                            .Where(a => a.IssueId == i.Id)
                            .Select(a => a.MemberId)
                            .ToList(),
                        TeamIds = _context.AssigneeTeams
                            .Where(a => a.IssueId == i.Id)
                            .Select(a => a.TeamId)
                            .ToList()
                    }
                }).ToListAsync();
        }

        private IQueryable<Issue> GetIssuesAsQuerable(int memberId, IssueStatus? status)
        {
            return _context.Applications
                .AsNoTracking()
                .Include(a => a.ApplicationTeams)
                    .ThenInclude(at => at.Team)
                        .ThenInclude(t => t.TeamMembers)
                .Where(a => a.ApplicationTeams
                    .Any(at => at.Team.TeamMembers
                        .Any(tm => tm.MemberId == memberId)))
                .SelectMany(a => a.Issues)
                .Where(issue => status == null || issue.Status == status);
        }

        public async Task<IssueMessage> GetEventMessageByIdAsync(int issueId, string eventId)
        {
            if (!_context.EventMessages.Any(em => em.IssueId == issueId && em.EventId == eventId))
            {
                throw new KeyNotFoundException("There is no event ID with such issue ID.");
            }

            var response = await _client.GetAsync<IssueMessage>(eventId);

            if (!response.IsValid)
            {
                throw new KeyNotFoundException("Event message not found");
            }

            response.Source.IssueId = issueId;

            return response.Source;
        }

        public async Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId)
        {
            var issue = await _context.Issues
                .Include(i => i.EventMessages)
                .FirstOrDefaultAsync(i => i.Id == issueId);

            var response = await _client.SearchAsync<IssueMessage>(s => s
                .Size(issue.EventMessages.Count)
                .Query(q => q
                    .Ids(c => c
                        .Values(issue.EventMessages.Select(i => i.EventId)))));

            if (!response.IsValid)
            {
                throw new KeyNotFoundException("Issue Message not found");
            }

            return response.Documents.OrderByDescending(em => em.OccurredOn).ToList();
        }

        public async Task<(ICollection<IssueMessage>, int)> GetEventMessagesByIssueIdLazyAsync(int issueId,
            FilterModel filterModel)
        {
            var events = _context.EventMessages.AsNoTracking().Where(e => e.IssueId == issueId);

            events = filterModel.SortOrder == 1 ? events.OrderBy(x => x.OccurredOn) : events.OrderByDescending(x => x.OccurredOn);
            IQueryable<string> temp = events.Skip(filterModel.First).Take(filterModel.Rows).Select(i => i.EventId);
            var values = temp.ToList();
            var response = await _client.SearchAsync<IssueMessage>(s => s
                .Size(filterModel.Rows)
                .Query(q => q
                    .Ids(c => c
                        .Values(values)))
                .Sort(q => filterModel.SortOrder == 1
                           ? q.Ascending(i => i.OccurredOn)
                           : q.Descending(i => i.OccurredOn)));

            var totalRecord = _context.EventMessages.Where(e => e.IssueId == issueId).Count();
            return (response.Documents.ToList(), totalRecord);
        }

        public Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto)
        {
            if (assigneeDto is null)
            {
                throw new ArgumentNullException(nameof(assigneeDto));
            }

            return UpdateAssigneeInternalAsync(assigneeDto);
        }

        public async Task<ICollection<IssueMessageDto>> GetAllIssueMessagesAsync()
        {
            var messages = await _context.EventMessages
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<ICollection<IssueMessageDto>>(messages);
        }


        public async Task<ICollection<IssueMessageDto>> GetAllIssueMessagesByApplicationIdAsync(int applicationId)
        {
            if (!await _context.Applications.AnyAsync(application => application.Id == applicationId))
            {
                throw new KeyNotFoundException("Application not found");
            }

            var messages = await _context.EventMessages
                .AsNoTracking()
                .Include(message => message.Issue)
                .Where(message => message.Issue.ApplicationId == applicationId)
                .ToListAsync();

            return _mapper.Map<ICollection<IssueMessageDto>>(messages);
        }

        public async Task<ICollection<IssueMessageDto>> GetAllIssueMessagesByApplicationIdAsync(
            int applicationId,
            IssueStatusesFilterDto statusesFilter)
        {
            if (!await _context.Applications.AnyAsync(application => application.Id == applicationId))
            {
                throw new KeyNotFoundException("Application not found");
            }

            var messages = await _context.EventMessages
                .AsNoTracking()
                .Include(message => message.Issue)
                .Where(message =>
                    message.Issue.ApplicationId == applicationId
                    && statusesFilter.IssueStatuses.Contains(message.Issue.Status))
                .ToListAsync();

            return _mapper.Map<ICollection<IssueMessageDto>>(messages);
        }

        public async Task UpdateIssueStatusAsync(UpdateIssueStatusDto issueStatusDto)
        {
            var issueEntity = await _context.Issues.FirstOrDefaultAsync(issue => issue.Id == issueStatusDto.IssueId)
                              ?? throw new KeyNotFoundException("Issue doesn't exist");

            issueEntity.Status = issueStatusDto.Status;
            _context.Update(issueEntity);
            await _context.SaveChangesAsync();
        }

        private async Task<Issue> CreateNewIssueAsync(IssueMessage issueMessage)
        {
            var newIssue = _mapper.Map<Issue>(issueMessage);
            var application = await _context.Applications.FirstOrDefaultAsync(a => a.ApiKey == issueMessage.ApiKey)
                ?? throw new KeyNotFoundException("No project with this API KEY!");

            newIssue.Status = IssueStatus.Active;

            newIssue.Application = application;
            var createdIssue = _context.Issues.Add(newIssue);

            await _context.SaveChangesAsync();

            return createdIssue.Entity;
        }

        private async Task UpdateAssigneeInternalAsync(UpdateAssigneeDto assigneeDto)
        {
            if (!await _context.Issues.AnyAsync(i => i.Id == assigneeDto.IssueId))
            {
                throw new KeyNotFoundException("Issue doesn't exist");
            }

            var oldMembers = await _context.AssigneeMembers
                .Where(a => a.IssueId == assigneeDto.IssueId)
                .ToListAsync(); // assignee members in db
            var membersToAdd = assigneeDto.Assignee.MemberIds
                .Except(oldMembers.Select(a => a.MemberId)); // members in db - members in dto
            var membersToDelete = oldMembers
                .Where(m => assigneeDto.Assignee.MemberIds.All(id =>
                    m.MemberId != id)); // members in dto - members in db

            await _context.AssigneeMembers.AddRangeAsync(
                membersToAdd.Select(id => new AssigneeMember
                {
                    IssueId = assigneeDto.IssueId,
                    MemberId = id
                }));

            _context.AssigneeMembers.RemoveRange(membersToDelete);

            var oldTeams = await _context.AssigneeTeams
                .Where(a => a.IssueId == assigneeDto.IssueId)
                .ToListAsync(); // assignee teams in db
            var teamsToAdd = assigneeDto.Assignee.TeamIds
                .Except(oldTeams.Select(a => a.TeamId)); // teams in db - teams in dto
            var teamsToDelete = oldTeams
                .Where(t => assigneeDto.Assignee.TeamIds.All(id => t.TeamId != id)); // teams in db - teams in dto

            await _context.AssigneeTeams.AddRangeAsync(
                teamsToAdd.Select(id => new AssigneeTeam
                {
                    IssueId = assigneeDto.IssueId,
                    TeamId = id
                }));

            _context.AssigneeTeams.RemoveRange(teamsToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<(ICollection<IssueLazyLoadDto>, int)> GetIssuesInfoLazyAsync(
            int memberId,
            FilterModel filterModel,
            IssueStatus? status)
        {
            if (await _context.Members.AllAsync(m => m.Id != memberId))
            {
                throw new KeyNotFoundException("There is no member with such ID.");
            }
            var issues = GetIssuesAsQuerable(memberId, status);
            var result = await issues
                .Select(i => new IssueLazyLoadDto
                {
                    IssueId = i.Id,
                    ErrorClass = i.ErrorClass,
                    ErrorMessage = i.ErrorMessage,
                    EventsCount = i.EventsCount,
                    Status = i.Status,
                    AffectedUsersCount = i.EventMessages
                        .Select(e => e.AffectedUserIdentifier)
                        .Where(t => !string.IsNullOrWhiteSpace(t))
                        .Distinct()
                        .Count(),
                    Assignee = new AssigneeDto
                    {
                        MemberIds = _context.AssigneeMembers
                            .Where(a => a.IssueId == i.Id)
                            .Select(a => a.MemberId)
                            .ToList(),
                        TeamIds = _context.AssigneeTeams
                            .Where(a => a.IssueId == i.Id)
                            .Select(a => a.TeamId)
                            .ToList()
                    },
                    NewestId = i.Newest.EventId,
                    OccurredOn = i.Newest.OccurredOn,
                    ProjectId = i.ApplicationId,
                    ProjectName = i.Application.Name
                })
                .Filter(filterModel, out var totalRecord)
                .ToListAsync();
            return (result, totalRecord);
        }


        public async Task<int> GetFilteredIssueCountByStatusesAndDateRangeByApplicationIdAsync(int applicationId,
            IssueStatusesByDateRangeFilter filter)
        {
            if (!await _context.Applications.AnyAsync(application => application.Id == applicationId))
            {
                throw new KeyNotFoundException("Application not found");
            }

            var messagesCount = await _context.EventMessages
                .AsNoTracking()
                .Include(message => message.Issue)
                .CountAsync(message => message.Issue.ApplicationId == applicationId
                                  && filter.IssueStatuses.Contains(message.Issue.Status)
                                  && message.OccurredOn >= filter.DateRange);
            return messagesCount;
        }

        public async Task<IssueSolutionDto> GetIssueSolutionLinkByIssueIdAsync(int issueId)
        {
            var issueEntity = await _context.Issues
               .AsNoTracking()
               .Include(issue => issue.Application)
                   .ThenInclude(application => application.Platform)
               .FirstOrDefaultAsync(issue => issue.Id == issueId)
               ?? throw new KeyNotFoundException("Issue not found");

            var issueSolution = await StackExchangeService.GetSolutionFromStackoverflow<IssueSolution>(issueEntity.ErrorMessage, new string[] { issueEntity.Application.Platform.Name });

            return _mapper.Map<IssueSolutionDto>(issueSolution);
        }
    }
}
