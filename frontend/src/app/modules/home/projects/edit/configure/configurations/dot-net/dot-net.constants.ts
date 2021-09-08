export const packageVersion = '1.0.1';
export const packageName = 'Watchdog.DotNet';

export const packageManagerInstallationCommand = `Install-Package ${packageName} -Version ${packageVersion}`;
export const dotnetCliInstallationCommand = `dotnet add package ${packageName} --version ${packageVersion}`;

export const sample = (apiKey: string) =>
    `using System;
using Watchdog.DotNet;

namespace ConsoleApp
{
    class Program
    {
        private static WatchdogClient _client = new("${apiKey}");


        public static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Your code here
            throw new Exception("works");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _client.Send(e.ExceptionObject as Exception);
        }
    }
}`;

export const tryCatchSample = `try
{
    // Your code here
}
catch (Exception e)
{
    _client.Send(e);
}
`;
