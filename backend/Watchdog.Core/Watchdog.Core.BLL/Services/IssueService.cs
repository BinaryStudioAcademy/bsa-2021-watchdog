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
            var totalHits = await GetTotalHits();
            
            var searchResponse = await _client.SearchAsync<IssueMessage>(s => s
                .Source(sf => sf
                    .Includes(i => i 
                        .Fields(
                            f => f.IssueDetails.ClassName,
                            f => f.IssueDetails.ErrorMessage,
                            f => f.OccurredOn
                        )
                    )
                )
                .From(0)
                .Size(totalHits)
            );

            var issueMessages = searchResponse
                .Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                })
                .OrderByDescending(i => i.OccurredOn);

            var issues = issueMessages
                .GroupBy(i => new { i.IssueDetails.ClassName, i.IssueDetails.ErrorMessage })
                .Select(group => new IssueInfoDto()
                {
                    ErrorMessage = group.Key.ErrorMessage,
                    ErrorClass = group.Key.ClassName,
                    EventsCount = issueMessages
                        .Count(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage),
                    Newest = issueMessages
                        .FirstOrDefault(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage).OccurredOn,
                    Oldest = issueMessages
                        .LastOrDefault(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage).OccurredOn
                })
                .OrderByDescending(issue => issue.Newest)
                .ToList();
            
            return issues;
        }

        public async Task<IssueDto> GetIssueAsync(string errorMessage)
        {
            var totalHits = await GetTotalHits();

            var searchResponse = await _client.SearchAsync<IssueMessage>(s => s
                .Query(q => q
                    .Match(m =>
                        m.Field(f => f.IssueDetails.ErrorMessage)
                            .Query(errorMessage)))
                .From(0)
                .Size(totalHits)
            );
            
            var issueMessages = searchResponse
                .Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                })
                .OrderByDescending(i => i.OccurredOn);
            
            var issue = issueMessages
                .GroupBy(i => new { i.IssueDetails.ClassName, i.IssueDetails.ErrorMessage })
                .Select(group => new IssueDto()
                {
                    ErrorMessage = group.Key.ErrorMessage,
                    ErrorClass = group.Key.ClassName,
                    Events = issueMessages
                        .Where(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage)
                        .ToList(),
                    EventsCount = issueMessages
                        .Count(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage),
                    Newest = issueMessages
                        .FirstOrDefault(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage).OccurredOn,
                    Oldest = issueMessages
                        .LastOrDefault(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage).OccurredOn
                })
                .FirstOrDefault();

            return issue;
        }

        private async Task<int> GetTotalHits()
        {
            var totalHits = await _client.CountAsync<IssueMessage>();
            return (int)totalHits.Count;
        }
    }
}