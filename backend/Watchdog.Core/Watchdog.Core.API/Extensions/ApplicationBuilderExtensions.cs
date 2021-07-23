using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseWatchdogCoreContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<WatchdogCoreContext>();
            context.Database.Migrate();
        }
    }
}
