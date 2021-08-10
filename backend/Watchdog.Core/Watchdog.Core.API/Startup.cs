using System;
using System.Collections.Generic;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using Serilog;
using Watchdog.Core.API.Extensions;
using Watchdog.Core.API.Middlewares;
using Watchdog.Core.BLL.Services;
using Watchdog.RabbitMQ.Shared.Models;
using Watchdog.RabbitMQ.Shared.Services;

namespace Watchdog.Core.API
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWatchdogCoreContext(Configuration);

            services.RegisterCustomServices(Configuration);

            services.AddValidation();

            services.AddAutoMapper();

            services.AddHealthChecks();

            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "Watchdog.Core", Version = "v1" });
                o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme.",
                    In = ParameterLocation.Header
                });
                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Scheme = "oauth2",
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddFluentValidationRulesToSwagger();
            // test rabbitmq
            services.AddSingleton(x =>
            {
                var amqpConnection = new Uri(Configuration.GetSection("RabbitMQConfiguration").GetSection("Uri").Value);
                var connectionFactory = new ConnectionFactory { Uri = amqpConnection };
                return connectionFactory.CreateConnection();
            });
            var producerSettings = new ProducerSettings();
            Configuration.GetSection("RabbitMQConfiguration:Queues:Test").Bind(producerSettings);
            services.AddScoped(provider =>
                new QueueService(new Producer(provider.GetRequiredService<IConnection>(), producerSettings)));
            // test rabbitmq
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var apiPrefix = env.IsProduction() ? "/api" : string.Empty;

            app.UseDeveloperExceptionPage();

            app.UseSerilogRequestLogging();

            app.UseCors("AnyOrigin");

            app.UseMiddleware<GenericExceptionHandlerMiddleware>();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSwagger(o =>
            {
                if (env.IsProduction())
                    o.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
                    {
                        new() {Url = $"https://{httpReq.Host.Value}{apiPrefix}"}
                    });
            });
            app.UseSwaggerUI(c => { c.SwaggerEndpoint($"{apiPrefix}/swagger/v1/swagger.json", "Watchdog.Core v1"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseWatchdogCoreContext();
        }
    }
}