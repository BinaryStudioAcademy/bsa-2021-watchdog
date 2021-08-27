import { appsetting, configure, configureServices } from './asp-net-core.constants';
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
        this.appsetting = appsetting(this.apiKey);
        this.configureServices = configureServices;
        this.configure = configure;
    }
}
