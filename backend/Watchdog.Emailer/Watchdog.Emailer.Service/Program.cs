using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SendGrid;
using Watchdog.Emailer.Service.Abstractions;
using Watchdog.Emailer.Service.HostedServices;
using Watchdog.Emailer.Service.Services;
using Watchdog.Emailer.Service.Settings;

namespace Watchdog.Emailer.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Host created.");

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<EmailService>();
                    services.AddSingleton<ISendGridClient>(x => 
                        new SendGridClient(context.Configuration["SendGrid:ApiKey"]));
                    services.AddSingleton<IEmailSender, SendGridEmailSender>();
                    services.AddOptions()
                        .Configure<RabbitMQSettings>(context.Configuration.GetSection("RabbitMQConfiguration"))
                        .Configure<SendGrigSettings>(context.Configuration.GetSection("SendGrid"));
                });
        }
    }
}
