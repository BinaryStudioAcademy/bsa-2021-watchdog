using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using Issue = Watchdog.Core.DAL.Entities.Issue;

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

        public async Task AddIssueEvent(IssueMessage issueMessage)
        {
            var issue = await _context.Issues.FirstOrDefaultAsync(i =>
                i.ErrorMessage == issueMessage.IssueDetails.ErrorMessage &&
                i.ErrorClass == issueMessage.IssueDetails.ClassName);

            if (issue is null)
            {
                var createdIssue = _context.Issues.Add(new Issue()
                {
                    ErrorClass = issueMessage.IssueDetails.ClassName,
                    ErrorMessage = issueMessage.IssueDetails.ErrorMessage
                }).Entity;
                
                createdIssue.EventMessages.Add(new EventMessage()
                {
                    EventId = issueMessage.Id,
                    OccurredOn = issueMessage.OccurredOn
                });
                
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.EventMessages.Add(new EventMessage()
                {
                    EventId = issueMessage.Id,
                    IssueId = issue.Id,
                    OccurredOn = issueMessage.OccurredOn
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync()
        {
            var issuesInfo = await _context.Issues
                .Select(i => new IssueInfoDto()
                {
                    IssueId = i.Id,
                    ErrorClass = i.ErrorClass,
                    ErrorMessage = i.ErrorMessage,
                    EventsCount = _context.EventMessages.Count(em => em.IssueId == i.Id),
                    Newest = new IssueMessageDto()
                    {
                        Id = _context.EventMessages
                            .FirstOrDefault(em => em.IssueId == i.Id).EventId,
                        OccurredOn = _context.EventMessages
                            .Where(em => em.IssueId == i.Id)
                            .OrderByDescending(em => em.OccurredOn)
                            .FirstOrDefault().OccurredOn
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
                })
                .OrderByDescending(i => i.Newest.OccurredOn)
                .ToListAsync();

            return issuesInfo;
        }

        public async Task<IssueMessage> GetEventMessageByIdAsync(string eventId)
        {
            var response = await _client.GetAsync<IssueMessage>(eventId);

            if (!response.IsValid)
            {
                throw new KeyNotFoundException("Event message not found");
            }

            var eventMessage = await _context.EventMessages.FirstOrDefaultAsync(i => i.EventId == eventId);

            response.Source.Id = eventId;
            response.Source.IssueId = eventMessage.IssueId;
            return response.Source;
        }

        public async Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId)
        {
            var issue = await _context.Issues.FirstOrDefaultAsync(i => i.Id == issueId);

            var response = await _client.SearchAsync<IssueMessage>(s => s
                .Query(q => q
                    .Ids(c => c
                        .Values(issue.EventMessages.Select(i => i.EventId)))));

            if (!response.IsValid)
            {
                throw new KeyNotFoundException("Issue Message not found");
            }
            
            return response.Documents.ToList();
        }
        
        private async Task<int> GetTotalHitsAsync<T>() where T : class
        {
            var totalHits = await _client.CountAsync<T>();
            return (int)totalHits.Count;
        }

        public Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto)
        {
            if (assigneeDto is null)
            {
                throw new System.ArgumentNullException(nameof(assigneeDto));
            }

            return UpdateAssigneeInternalAsync(assigneeDto);
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
                .Where(m => !assigneeDto.Assignee.MemberIds.Any(id => m.MemberId == id)); // members in dto - members in db

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
                .Where(t => !assigneeDto.Assignee.TeamIds.Any(id => t.TeamId == id)); // teams in db - teams in dto

            await _context.AssigneeTeams.AddRangeAsync(
                teamsToAdd.Select(id => new AssigneeTeam
                {
                    IssueId = assigneeDto.IssueId,
                    TeamId = id
                }));

            _context.AssigneeTeams.RemoveRange(teamsToDelete);

            await _context.SaveChangesAsync();
        }
    }
}