using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Nest;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.DAL.Context;
using Watchdog.Models.Shared.Analytics;

namespace Watchdog.Core.BLL.Services
{
    public class AnalyticsService : BaseService, IAnalyticsService
    {
        private readonly IElasticClient _client;

        public AnalyticsService(WatchdogCoreContext context, IMapper mapper, IElasticClient client)
            : base(context, mapper)
        {
            _client = client;
        }

        public async Task<ICollection<ResponseInfo>> GetResponsesInfo(ApplicationDto[] applications, int count)
        {
            var searchResponse = _client.Search<ResponseInfo>(s => s
                .Sort(sortDescriptor => sortDescriptor
                    .Descending(response => response.Time))
                .Size(count)
            );

            var appKeys = applications.Select(a => a.ApiKey);

            return searchResponse.Documents
                .Where(resp => appKeys.Contains(resp.ProjectKey))
                .ToList();
        }
    }
}