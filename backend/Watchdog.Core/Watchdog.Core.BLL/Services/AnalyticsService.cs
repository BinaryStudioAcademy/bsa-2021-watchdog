using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Nest;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.Enums.Tiles;
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

        public async Task<ICollection<ResponseInfo>> GetResponsesInfo(ApplicationDto[] applications, TileDateRangeType dateRangeTypeType, int count)
        {
            var date = GetDateRangeTime(dateRangeTypeType);
            
            var searchResponse = await _client.SearchAsync<ResponseInfo>(s => s
                .Query(q => q
                    .DateRange(r => r
                        .Field(f => f.Date)
                        .GreaterThanOrEquals(date)
                    )
                )
                .Sort(sortDescriptor => sortDescriptor
                    .Descending(response => response.Time))
                .Size(count)
            );

            var appKeys = applications.Select(a => a.ApiKey);

            return searchResponse.Documents
                .Where(resp => appKeys.Contains(resp.ProjectKey))
                .ToList();
        }

        private static DateTime GetDateRangeTime(TileDateRangeType dateRangeType)
        {
            return dateRangeType switch
            {
                TileDateRangeType.ThePastHour => DateTime.Now.AddHours(-1),
                TileDateRangeType.ThePastDay => DateTime.Now.AddDays(-1),
                TileDateRangeType.ThePast2Days => DateTime.Now.AddDays(-2),
                TileDateRangeType.ThePastWeek => DateTime.Now.AddDays(-7),
                TileDateRangeType.ThePast2Weeks => DateTime.Now.AddDays(-14),
                TileDateRangeType.ThePast30Days => DateTime.Now.AddDays(-30),
                TileDateRangeType.ThePastYear => DateTime.Now.AddYears(-1),
                TileDateRangeType.All => DateTime.Now,
                _ => throw new ArgumentException("No such tile date range")
            };
        }
    }
}