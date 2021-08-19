using System;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.NetCore.Common.Builders
{
    public class WatchdogMessageBuilder : IWatchdogMessageBuilder
    {
        private readonly WatchdogMessage _watchdogMessage;
        private readonly WatchdogSettingsBase _settings;

        public static WatchdogMessageBuilder New(WatchdogSettingsBase settings)
        {
            return new WatchdogMessageBuilder(settings);
        }

        private WatchdogMessageBuilder(WatchdogSettingsBase settings)
        {
            _watchdogMessage = new WatchdogMessage();
            _settings = settings;
        }

        public WatchdogMessage Build()
        {
            return _watchdogMessage;
        }

        public IWatchdogMessageBuilder SetTimeStamp(DateTime? currentTime)
        {
            if (currentTime != null)
            {
                _watchdogMessage.OccurredOn = currentTime.Value;
            }
            return this;
        }

        public IWatchdogMessageBuilder SetMachineName(string machineName)
        {
            _watchdogMessage.Details.MachineName = machineName;
            return this;
        }

        public IWatchdogMessageBuilder SetEnvironmentDetails()
        {
            _watchdogMessage.Details.Environment = WatchdogEnvironmentBuilder.Build(_settings);
            return this;
        }

        public IWatchdogMessageBuilder SetExceptionDetails(Exception exception)
        {
            if (exception != null)
            {
                _watchdogMessage.Details.Error = WatchdogErrorMessageBuilder.Build(exception);
            }
            return this;
        }

        public IWatchdogMessageBuilder SetRequestDetails(WatchdogRequestMessage message)
        {
            _watchdogMessage.Details.Request = message;
            return this;
        }

        public IWatchdogMessageBuilder SetResponseDetails(WatchdogResponseMessage message)
        {
            _watchdogMessage.Details.Response = message;
            return this;
        }
    }
}
