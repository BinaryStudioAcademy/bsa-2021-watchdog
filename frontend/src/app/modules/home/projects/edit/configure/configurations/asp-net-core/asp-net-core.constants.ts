export const appsetting = (apiKey: string) => `{
    // other setting
    "WatchdogSettings": {
        "ApiKey": "${apiKey}"
    }
}
`;
export const configureServices = `public IConfiguration Configuration { get; }

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(Configuration);

    // other services

    services.AddWatchdog();

    // other services
}
`;

export const configure = `public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // If you have a generic exception handler, then it should be here.

    app.UseWatchdog();

    // other middlewares

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
`;
