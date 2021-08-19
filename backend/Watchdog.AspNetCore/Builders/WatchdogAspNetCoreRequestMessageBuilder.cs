using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.AspNetCore.Builders
{
    public class WatchdogAspNetCoreRequestMessageBuilder
    {
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

            if (ip == null)
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
            IDictionary queryString = null;

            try
            {
                queryString = ToDictionary(request.Query);
            }
            catch (Exception e)
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
                    headers[header.Key] = string.Join(",", header.Value);
                }
            }
            catch (Exception e)
            {
                headers = new Dictionary<string, string>() { { "Failed to retrieve", e.Message } };
            }

            return headers;
        }

        private static IDictionary ToDictionary(IQueryCollection query)
        {
            var dict = new Dictionary<string, string>();

            foreach (var value in query)
            {
                dict[value.Key] = string.Join(",", value.Value);
            }

            return dict;
        }
    }
}
