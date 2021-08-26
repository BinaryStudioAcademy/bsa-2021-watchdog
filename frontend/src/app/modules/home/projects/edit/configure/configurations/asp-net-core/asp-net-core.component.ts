import { Component, OnInit, Input } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';

@Component({
    selector: 'app-asp-net-core',
    templateUrl: './asp-net-core.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class AspNetCoreComponent extends BaseConfigurationComponent implements OnInit {
    @Input() apiKey: string;

    appsetting: string;

    configureServices: string;

    configure: string;

    ngOnInit(): void {
        this.appsetting = `{
    // other setting
    "WatchdogSettings": {
        "ApiKey": "${this.apiKey}"
    }
}
`;
        this.configureServices = `public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // other services

    services.AddWatchdog();

    // other services
}
`;

        this.configure = `public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
    }
}
