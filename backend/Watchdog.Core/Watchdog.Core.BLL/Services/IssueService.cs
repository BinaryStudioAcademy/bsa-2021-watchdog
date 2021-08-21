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

        public async Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync()
        {
            var issues = await GetIssuesAsync();
            var issueMessages = await GetIssueMessagesAsync();

            var issuesInfo = issues
                .Select(i => new IssueInfoDto()
                {
                    IssueId = i.Id,
                    ErrorClass = i.ErrorClass,
                    ErrorMessage = i.ErrorMessage,
                    EventsCount = issueMessages.Count(issueMessage =>
                        issueMessage.IssueDetails.ErrorMessage == i.ErrorMessage),
                    Newest = new IssueMessageDto()
                    {
                        Id = issueMessages
                            .FirstOrDefault(issueMessage => issueMessage.IssueId == i.Id).Id,
                        OccurredOn = issueMessages
                            .Where(issueMessage => issueMessage.IssueId == i.Id)
                            .OrderByDescending(issueMessage => issueMessage.OccurredOn)
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
                .ToList();

            return issuesInfo;
        }

        public async Task<IssueMessage> GetIssueMessageByIdAsync(string issueId)
        {
            var response = await _client
                .GetAsync<IssueMessage>(issueId);
            if (!response.IsValid)
                throw new KeyNotFoundException("Issue Message not found");

            var result = response.Source;
            result.Id = issueId;
            return result;
        }

        public async Task<ICollection<IssueMessage>> GetIssuesMessagesByParentIdAsync(string parentIssueId)
        {
            var issueMessagesCount = await GetTotalHitsAsync<IssueMessage>();
            var issueMessagesResponse = await _client
                .SearchAsync<IssueMessage>(descriptor => descriptor
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.IssueId)
                            .Query(parentIssueId)
                        )
                    )
                    .From(0)
                    .Size(issueMessagesCount));
            if (!issueMessagesResponse.IsValid)
                throw new KeyNotFoundException("Issue Messages not found");

            var issueMessages = issueMessagesResponse
                .Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                })
                .ToList();

            return issueMessages;
        }

        private async Task<ICollection<Issue>> GetIssuesAsync()
        {
            var issuesCount = await GetTotalHitsAsync<Issue>();

            var issuesSearchResponse = await _client.SearchAsync<Issue>(s => s
                .From(0)
                .Size(issuesCount)
            );

            var issues = issuesSearchResponse
                .Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                })
                .ToList();

            return issues;
        }

        private async Task<ICollection<IssueMessage>> GetIssueMessagesAsync()
        {
            var issueMessagesCount = await GetTotalHitsAsync<IssueMessage>();

            var searchResponse = await _client.SearchAsync<IssueMessage>(s => s
                .Source(sf => sf
                    .Includes(fd => fd
                        .Field(f => f.IssueId)
                        .Field(f => f.IssueDetails.ErrorMessage)
                        .Field(f => f.OccurredOn))
                )
                .From(0)
                .Size(issueMessagesCount)
            );

            var issueMessages = searchResponse
                .Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                })
                .ToList();

            return issueMessages;
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
            if (!(await _client.GetAsync<Issue>(assigneeDto.IssueId)).IsValid)
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