using System;
using System.Globalization;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.NetCore.Common.Builders
{
    public class WatchdogEnvironmentBuilder
    {
        protected WatchdogEnvironmentBuilder()
        {
        }

        public static WatchdogEnvironmentMessage Build(WatchdogSettingsBase settings)
        {
            var message = new WatchdogEnvironmentMessage();

            message.UtcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Hours;
            message.Locale = CultureInfo.CurrentCulture.DisplayName;
            message.Platform = Environment.OSVersion.Platform.ToString();
            message.SystemType = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";

            return message;
        }
    }
}
