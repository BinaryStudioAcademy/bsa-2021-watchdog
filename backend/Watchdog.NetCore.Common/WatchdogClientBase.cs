using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Watchdog.NetCore.Common.Builders;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.NetCore.Common
{
    public abstract class WatchdogClientBase
    {
        private static readonly HttpClient _client = new HttpClient();
        
        private readonly List<Type> _wrapperExceptions = new List<Type>();
        
        protected readonly WatchdogSettingsBase _settings;

        public WatchdogClientBase(WatchdogSettingsBase settings)
        {
            _settings = settings;

            _wrapperExceptions.Add(typeof(TargetInvocationException));
        }

        public void AddWrapperExceptions(params Type[] wrapperExceptions)
        {
            foreach (Type wrapper in wrapperExceptions)
            {
                if (!_wrapperExceptions.Contains(wrapper))
                {
                    _wrapperExceptions.Add(wrapper);
                }
            }
        }

        public void RemoveWrapperExceptions(params Type[] wrapperExceptions)
        {
            foreach (Type wrapper in wrapperExceptions)
            {
                _wrapperExceptions.Remove(wrapper);
            }
        }

        protected virtual bool CanSend(Exception exception)
        {
            return exception != null || exception.Data != null;
        }

        protected virtual bool CanSend(WatchdogMessage message)
        {
            return true;
        }

        public async Task Send(Exception exception)
        {
            await SendAsync(exception);
        }

        protected virtual async Task SendAsync(Exception exception)
        {
            if (CanSend(exception))
            {
                await StripAndSend(exception);
            }
        }

        public Task SendInBackground(Exception exception)
        {
            return SendInBackgroundAsync(exception);
        }

        public virtual async Task SendInBackgroundAsync(Exception exception)
        {
            if (CanSend(exception))
            {
                await StripAndSend(exception);
            }
        }

        protected async Task StripAndSend(Exception exception)
        {
            foreach (Exception e in StripWrapperExceptions(exception))
            {
                await Send(BuildMessage(e));
            }
        }

        protected IEnumerable<Exception> StripWrapperExceptions(Exception exception)
        {
            if (exception != null && _wrapperExceptions.Any(wrapperException =>
                exception.GetType() == wrapperException && exception.InnerException != null))
            {
                AggregateException aggregate = exception as AggregateException;

                if (aggregate != null)
                {
                    foreach (Exception e in aggregate.InnerExceptions)
                    {
                        foreach (Exception ex in StripWrapperExceptions(e))
                        {
                            yield return ex;
                        }
                    }
                }
                else
                {
                    foreach (Exception e in StripWrapperExceptions(exception.InnerException))
                    {
                        yield return e;
                    }
                }
            }
            else
            {
                yield return exception;
            }
        }

        protected virtual WatchdogMessage BuildMessage(Exception exception)
        {
            return WatchdogMessageBuilder.New(_settings)
                .SetTimeStamp(DateTime.Now)
                .SetMachineName(Environment.MachineName)
                .SetEnvironmentDetails()
                .SetExceptionDetails(exception)
                .Build();
        }

        public async Task Send(WatchdogMessage watchdogMessage)
        {
            bool canSend = CanSend(watchdogMessage);

            if (!canSend)
            {
                return;
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _settings.ApiEndpoint);

            var message = JsonConvert.SerializeObject(watchdogMessage, Formatting.Indented);
            requestMessage.Content = new StringContent(message, Encoding.UTF8, "application/json");

            await _client.SendAsync(requestMessage);
        }
    }
}
