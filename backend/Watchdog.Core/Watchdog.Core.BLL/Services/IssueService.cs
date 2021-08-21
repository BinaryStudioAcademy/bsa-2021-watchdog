using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using Issue = Watchdog.Core.DAL.Entities.Issue;

namespace Watchdog.Core.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly IElasticClient _client;
        private readonly IMapper _mapper;
        private readonly WatchdogCoreContext _context;

        public IssueService(IElasticClient client, WatchdogCoreContext context, IMapper mapper)
        {
            _context = context;
            _client = client;
            _mapper = mapper;
        }

        public async Task AddIssueEvent(IssueMessage issueMessage)
        {
            var eventMessage = _mapper.Map<EventMessage>(issueMessage);

            var issue = await _context.Issues.FirstOrDefaultAsync(i =>
                i.ErrorMessage == issueMessage.IssueDetails.ErrorMessage &&
                i.ErrorClass == issueMessage.IssueDetails.ClassName);

            if (issue == null)
            {
                var newIssue = _mapper.Map<Issue>(issueMessage);
                var createdIssue = _context.Issues.Add(newIssue).Entity;
                _context.EventMessages.Add(new EventMessage()
                {
                    EventId = issueMessage.Id,
                    IssueId = createdIssue.Id
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.EventMessages.Add(new EventMessage()
                {
                    EventId = issueMessage.Id,
                    IssueId = issue.Id
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync()
        {
            var issueMessages = await GetIssueMessagesAsync();
            var issues = await _context.Issues.ToListAsync();

            var issuesInfo = issues
                .Select(i => new IssueInfoDto()
                {
                    ErrorClass = i.ErrorClass,
                    ErrorMessage = i.ErrorMessage,
                    EventsCount = _context.EventMessages.Count(em => em.IssueId == i.Id),
                    Newest = new IssueMessageDto()
                    {
                        Id = _context.EventMessages
                            .FirstOrDefault(em => em.IssueId == i.Id)?.EventId,
                        OccurredOn = _context.EventMessages
                            .Where(em => em.IssueId == i.Id)
                            .OrderByDescending(issueMessage => issueMessage.OccurredOn)
                            .FirstOrDefault().OccurredOn
                    },
                    Assignee = i.Assignee
                });

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
            return (int) totalHits.Count;
        }

        public async Task UpdateAssignee(UpdateAssigneeDto assigneeDto)
        {
            var issueResponse = await _client.GetAsync<Issue>(assigneeDto.IssueId);
            if (!issueResponse.IsValid)
            {
                throw new KeyNotFoundException("Issue doesn't exist");
            }

            var issue = issueResponse.Source;

            issue.Assignee = assigneeDto.Assignee;
            await _client.UpdateAsync<Issue, Issue>(assigneeDto.IssueId, descriptor => descriptor
                        .Doc(issue));
        }
    }
}