using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.Enums.Tiles;
using Watchdog.Models.Shared.Analytics;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IAnalyticsService
    {
        Task<ICollection<ResponseInfo>> GetResponsesInfo(string[] appKeys, TileDateRangeType dateRangeTypeType, int count);
    }
}