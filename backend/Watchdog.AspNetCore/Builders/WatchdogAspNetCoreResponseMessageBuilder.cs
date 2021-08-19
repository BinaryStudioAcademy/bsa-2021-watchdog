using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.AspNetCore.Builders
{
    public class WatchdogAspNetCoreResponseMessageBuilder
    {
        public static WatchdogResponseMessage Build(HttpContext context)
        {
            var httpResponseFeature = context.Features.Get<IHttpResponseFeature>();
            return new WatchdogResponseMessage
            {
                StatusCode = context.Response.StatusCode,
                StatusDescription = httpResponseFeature?.ReasonPhrase
            };
        }
    }
}
