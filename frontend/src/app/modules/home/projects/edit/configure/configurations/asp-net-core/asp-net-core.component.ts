import * as aspNetCoreConstants from './asp-net-core.constants';
import { Component, OnInit, Input } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';

@Component({
    selector: 'app-asp-net-core',
    templateUrl: './asp-net-core.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class AspNetCoreComponent extends BaseConfigurationComponent implements OnInit {
    @Input() apiKey: string;

    packageManagerInstallationCommand: string;
    dotnetCliInstallationCommand: string;
    configureServices: string;
    appsettings: string;
    sample: string;

    ngOnInit(): void {
        this.packageManagerInstallationCommand = aspNetCoreConstants.packageManagerInstallationCommand;
        this.dotnetCliInstallationCommand = aspNetCoreConstants.dotnetCliInstallationCommand;
        this.configureServices = aspNetCoreConstants.configureServices;
        this.appsettings = aspNetCoreConstants.appsettings(this.apiKey);
        this.sample = aspNetCoreConstants.sample;
    }
}
