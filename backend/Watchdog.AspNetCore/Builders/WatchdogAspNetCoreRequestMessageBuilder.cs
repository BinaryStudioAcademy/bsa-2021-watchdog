using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.AspNetCore.Builders
{
    public class WatchdogAspNetCoreRequestMessageBuilder
    {
        protected WatchdogAspNetCoreRequestMessageBuilder()
        {
        }

        public static WatchdogRequestMessage Build(HttpContext context)
        {
            var request = context.Request;

            return new WatchdogRequestMessage
            {
                HostName = request.Host.Value,
                Url = request.GetDisplayUrl(),
                HttpMethod = request.Method,
                IPAddress = GetIpAddress(context.Connection),
                QueryString = GetQueryString(request),
                Headers = GetHeaders(request)
            };
        }

        private static string GetIpAddress(ConnectionInfo connection)
        {
            var ip = connection.RemoteIpAddress ?? connection.LocalIpAddress;

            if (ip is null)
            {
                return "";
            }

            int? port = connection.RemotePort == 0 ? connection.LocalPort : connection.RemotePort;

            if (port != 0)
            {
                return ip + ":" + port.Value;
            }

            return ip.ToString();
        }

        private static IDictionary GetQueryString(HttpRequest request)
        {
            IDictionary queryString = new Dictionary<string, string>();

            try
            {
                foreach (var value in request.Query)
                {
                    queryString[value.Key] = string.Join(",", value.Value.AsEnumerable());
                }
            }
            catch (Exception e) when (e is ArgumentNullException || e is OutOfMemoryException)
            {
                queryString = new Dictionary<string, string>() { { "Failed to retrieve", e.Message } };
            }

            return queryString;
        }

        private static IDictionary GetHeaders(HttpRequest request)
        {
            IDictionary headers = new Dictionary<string, string>();
            try
            {
                foreach (var header in request.Headers)
                {
                    headers[header.Key] = string.Join(",", header.Value.AsEnumerable());
                }
            }
            catch (Exception e) when (e is ArgumentNullException || e is OutOfMemoryException)
            {
                headers = new Dictionary<string, string>() { { "Failed to retrieve", e.Message } };
            }

            return headers;
        }
    }
}
