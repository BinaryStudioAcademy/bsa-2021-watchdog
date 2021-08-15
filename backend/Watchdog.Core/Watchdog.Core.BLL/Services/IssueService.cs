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
                            f => f.ClassName,
                            f => f.ErrorMessage,
                            f => f.OccurredOn
                        )
                    )
                )
                .From(0)
                .Size(totalHits)
            );

            var issueMessages = searchResponse.Documents.OrderByDescending(i => i.OccurredOn);

            var issues = issueMessages
                .GroupBy(i => new { i.ClassName, i.ErrorMessage })
                .Select(group => new IssueInfoDto()
                {
                    ErrorMessage = group.Key.ErrorMessage,
                    ErrorClass = group.Key.ClassName,
                    EventsCount = issueMessages
                        .Count(i => i.ErrorMessage == group.Key.ErrorMessage),
                    Newest = issueMessages
                        .FirstOrDefault(i => i.ErrorMessage == group.Key.ErrorMessage).OccurredOn,
                    Oldest = issueMessages
                        .LastOrDefault(i => i.ErrorMessage == group.Key.ErrorMessage).OccurredOn
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
                        m.Field(f => f.ErrorMessage)
                            .Query(errorMessage)))
                .From(0)
                .Size(totalHits)
            );
            
            var issueMessages = searchResponse.Documents;
            
            var issue = issueMessages
                .GroupBy(i => new { i.ClassName, i.ErrorMessage })
                .Select(group => new IssueDto()
                {
                    ErrorMessage = group.Key.ErrorMessage,
                    ErrorClass = group.Key.ClassName,
                    Events = issueMessages
                        .Where(i => i.ErrorMessage == group.Key.ErrorMessage)
                        .ToList(),
                    EventsCount = issueMessages
                        .Count(i => i.ErrorMessage == group.Key.ErrorMessage),
                    Newest = issueMessages
                        .FirstOrDefault(i => i.ErrorMessage == group.Key.ErrorMessage).OccurredOn,
                    Oldest = issueMessages
                        .LastOrDefault(i => i.ErrorMessage == group.Key.ErrorMessage).OccurredOn
                })
                .FirstOrDefault();

            return issue;
        }
        
        public async Task<ICollection<TileIssueInfoDto>> GetTileIssuesInfoAsync()
        {
            var totalHits = await GetTotalHits();
            
            var searchResponse = await _client.SearchAsync<IssueMessage>(s => s
                .Source(sf => sf
                    .Includes(i => i 
                        .Fields(
                            f => f.ClassName,
                            f => f.ErrorMessage
                        )
                    )
                )
                .From(0)
                .Size(totalHits)
            );

            var issueMessages = searchResponse.Documents;

            var issuesInfo = issueMessages
                .GroupBy(issue => new { issue.ClassName, issue.ErrorMessage })
                .Select(group => new TileIssueInfoDto()
                {
                    ErrorClass = group.Key.ClassName,
                    ErrorMessage = group.Key.ErrorMessage,
                    Events = issueMessages.Count(issueMsg => issueMsg.ErrorMessage == group.Key.ErrorMessage)
                })
                .OrderByDescending(i => i.Events)
                .ToList();
            
            return issuesInfo;
        }

        private async Task<int> GetTotalHits()
        {
            var totalHits = await _client.CountAsync<IssueMessage>();
            return (int)totalHits.Count;
        }
    }
}