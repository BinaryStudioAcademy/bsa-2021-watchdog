using System;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Nest;
using Watchdog.Core.BLL.MappingProfiles;
using Watchdog.Core.BLL.Services;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.Core.Common.Validators.Organization;
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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITileService, TileService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
        }
        
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ElasticConfiguration:Uri"];

            var settings = new ConnectionSettings(new Uri(connectionString))
                .DefaultMappingFor<IssueMessage>(
                    m => m.IndexName(configuration["ElasticConfiguration:IssueMessageIndex"]));
            
            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(OrganizationProfile)));
        }

        public static void AddValidation(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NewOrganizationDtoValidator>());
        }

        public static void AddWatchdogCoreContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration.GetConnectionString("WatchdogCoreDBConnection");
            services.AddDbContext<WatchdogCoreContext>(options =>
                options.UseSqlServer(
                    connectionsString,
                    opt => opt.MigrationsAssembly(typeof(WatchdogCoreContext).Assembly.GetName().Name)));
        }


        public static void AddEmailSendService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailSendService, EmailSendService>(provider => new EmailSendService(new BLL.Services.Options.EmailSendOptions
            {
                ApiKey = configuration["SENDGRID_API_KEY"], // you need to add SENDGRID_API_KEY to yours environment variables
                SenderEmail = configuration["SendGridConfiguration:SenderEmail"],
                SenderName = configuration["SendGridConfiguration:SenderName"],
                TemplateId = configuration["SendGridConfiguration:TemplateId"],  // templates you can create on sendgrid site
                                                                                 // for this template automatically sended in the promotions.
            }));
        }
    }
}
