import { main, errorHandler, appModule, setUser } from './angular.constants';
import { Component, OnInit } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';

@Component({
    selector: 'app-angular',
    templateUrl: './angular.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class AngularComponent extends BaseConfigurationComponent implements OnInit {
    install: string;
    main: string;
    errorHandler: string;
    appModule: string;
    setUser: string;

    ngOnInit(): void {
        this.install = 'npm install --save @watchdog-bsa/watchdog-js';
        this.main = main(this.apiKey);
        this.errorHandler = errorHandler;
        this.appModule = appModule;
        this.setUser = setUser;
    }
}
