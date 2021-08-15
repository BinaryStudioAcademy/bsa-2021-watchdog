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
        
        public async Task<ICollection<Issue>> GetIssuesAsync()
        {
            var issueMessages = await SearchIssueMessagesAsync();
            
            //it will be refactored letter : )
            var issues = issueMessages
                .GroupBy(i => new { i.ClassName, i.ErrorMessage })
                .Select(group => new Issue()
                {
                    ErrorMessage = group.Key.ErrorMessage,
                    ErrorClass = group.Key.ClassName,
                    Events = issueMessages.Where(i => i.ErrorMessage == group.Key.ErrorMessage).ToList(),
                    EventsCount = issueMessages.Count(i => i.ErrorMessage == group.Key.ErrorMessage),
                    Newest = issueMessages
                        .Where(i => i.ErrorMessage == group.Key.ErrorMessage)
                        .OrderBy(i => i.OccurredOn)
                        .LastOrDefault().OccurredOn,
                    Oldest = issueMessages
                        .Where(i => i.ErrorMessage == group.Key.ErrorMessage)
                        .OrderBy(i => i.OccurredOn)
                        .FirstOrDefault().OccurredOn,
                })
                .OrderByDescending(issue => issue.EventsCount)
                .ToList();
            
            return issues;
        }
        
        public async Task<ICollection<TileIssueInfo>> GetIssuesInfoAsync()
        {
            var issueMessages = await SearchIssueMessagesAsync();
            
            var issuesInfo = issueMessages
                .GroupBy(issue => new { issue.ClassName, issue.ErrorMessage })
                .Select(group => new TileIssueInfo()
                {
                    ErrorClass = group.Key.ClassName,
                    ErrorMessage = group.Key.ErrorMessage,
                    Events = issueMessages.Count(issueMsg => issueMsg.ErrorMessage == group.Key.ErrorMessage)
                })
                .OrderByDescending(i => i.Events)
                .ToList();
            
            return issuesInfo;
        }

        private async Task<ICollection<IssueMessage>> SearchIssueMessagesAsync()
        {
            var searchResponse = await _client.SearchAsync<IssueMessage>(s => s
                .From(0)
                .Size(300)
                .MatchAll()
                .Sort(sorter => sorter.Descending(issue => issue.OccurredOn))
            );

            return searchResponse.Documents.ToList();
        }
    }
}