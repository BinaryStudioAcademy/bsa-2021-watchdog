using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.AspNetCore.Builders
{
    public class WatchdogAspNetCoreResponseMessageBuilder
    {
        protected WatchdogAspNetCoreResponseMessageBuilder()
        {
        }

        public static WatchdogResponseMessage Build(HttpContext context)
        {
            return new WatchdogResponseMessage
            {
                StatusCode = context.Response.StatusCode,
                StatusDescription = ReasonPhrases.GetReasonPhrase(context.Response.StatusCode)
            };
        }
    }
}
