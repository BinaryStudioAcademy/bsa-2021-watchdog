using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.AspNetCore;

namespace Watchdog.Core.API.Middlewares
{
    public class GenericExceptionHandlerMiddleware
    {
        public const int SqlServerViolationOfUniqueIndex = 2601;

        private readonly RequestDelegate _next;
        private readonly ILogger<GenericExceptionHandlerMiddleware> _logger;
        private readonly IWatchdogAspNetCoreClientProvider _clientProvider;

        public GenericExceptionHandlerMiddleware(RequestDelegate next,
                                                 ILogger<GenericExceptionHandlerMiddleware> logger,
                                                 IWatchdogAspNetCoreClientProvider clientProvider)
        {
            _next = next;
            _logger = logger;
            _clientProvider = clientProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                ArgumentNullException => 400,
                AggregateException => 409,
                KeyNotFoundException => 404,
                DbUpdateException ex => (ex.InnerException as SqlException).Number == SqlServerViolationOfUniqueIndex ? 409 : 500,
                _ => 500
            };

            _clientProvider.GetClient(context).TrackException(exception);

            return context.Response.WriteAsync(exception is DbUpdateException ? exception.InnerException.Message : exception.Message);
        }
    }
}