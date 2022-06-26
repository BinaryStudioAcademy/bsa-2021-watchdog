using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.AspNetCore;
using Watchdog.Notifier.API.Extensions;
using Watchdog.Notifier.BLL.Hubs;

namespace Watchdog.Notifier.API
{
    public class Startup
    {
        public Startup(IConfiguration _, IHostEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                configurationBuilder.AddUserSecrets<Startup>();
            }

            Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    Configuration["CorsPolicy"],
                    builder => builder.WithOrigins(Configuration["AllowedOrigin"])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddControllers();
            services.AddHealthChecks();
            services.AddSignalR();

            services.AddRabbitMQIssueConsumer(Configuration);

            services.AddWatchdog(Configuration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = Configuration["Authentication:JwtBearer:Authority"];
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = Configuration["Authentication:JwtBearer:TokenValidation:Issuer"],
                            ValidateAudience = true,
                            ValidAudience = Configuration["Authentication:JwtBearer:TokenValidation:Audience"],
                            ValidateLifetime = true
                        };
                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = async context =>
                            {
                                var accessToken = context.Request.Query["access_token"];
                                var path = context.HttpContext.Request.Path;
                                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/issuesHub"))
                                {
                                    context.Token = accessToken;
                                }
                                await Task.CompletedTask;
                            },

                        };
                    });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // реєструємо endpoint
                endpoints.MapHub<IssuesHub>("/issuesHub");
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
