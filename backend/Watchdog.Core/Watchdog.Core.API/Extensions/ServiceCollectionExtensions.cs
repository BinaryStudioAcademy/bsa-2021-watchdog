using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Watchdog.Core.BLL.MappingProfiles;
using Watchdog.Core.BLL.Services;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.Validators.Sample;
using Watchdog.Core.DAL.Context;

namespace Watchdog.Core.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration _)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<ISampleService, SampleService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(SampleProfile)));
        }

        public static void AddValidation(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(fv => 
                    fv.RegisterValidatorsFromAssemblyContaining<NewSampleDtoValidator>()
                    .RegisterValidatorsFromAssemblyContaining<NewOrganizationDtoValidator>());
        }

        public static void AddWatchdogCoreContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration.GetConnectionString("WatchdogCoreDBConnection");
            services.AddDbContext<WatchdogCoreContext>(options =>
                options.UseSqlServer(
                    connectionsString,
                    opt => opt.MigrationsAssembly(typeof(WatchdogCoreContext).Assembly.GetName().Name)));
        }
    }
}
