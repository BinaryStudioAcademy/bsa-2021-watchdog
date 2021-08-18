using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly IElasticClient _client;
        
        public IssueService(IElasticClient client)
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
                    EventsCount = issueMessages.Count(issueMessage => issueMessage.IssueDetails.ErrorMessage == i.ErrorMessage),
                    Newest = new IssueMessageDto()
                    {
                        Id = issueMessages
                            .FirstOrDefault(issueMessage => issueMessage.IssueId == i.Id).Id,
                        OccurredOn = issueMessages
                            .Where(issueMessage => issueMessage.IssueId == i.Id)
                            .OrderByDescending(issueMessage => issueMessage.OccurredOn)
                            .FirstOrDefault().OccurredOn
                    }
                })
                .ToList();

            return issuesInfo;
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

        private async Task<int> GetTotalHitsAsync<T>() where T: class
        {
            var totalHits = await _client.CountAsync<T>();
            return (int)totalHits.Count;
        }

        public async Task UpdateAssignee(UpdateAssigneeDto assigneeDto)
        {
        }
    }
}