using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Watchdog.Core.API.Middlewares
{
    public class GenericExceptionHandlerMiddleware
    {
        public const int SqlServerViolationOfUniqueIndex = 2601;

        private readonly RequestDelegate _next;
        private readonly ILogger<GenericExceptionHandlerMiddleware> _logger;

        public GenericExceptionHandlerMiddleware(RequestDelegate next, ILogger<GenericExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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

        private static Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                ArgumentNullException => 400,
                DbUpdateException ex => (ex.InnerException as SqlException).Number == SqlServerViolationOfUniqueIndex ? 409 : 500,
                _ => 500
            };

            return context.Response.WriteAsync(exception.Message);
        }
    }
}