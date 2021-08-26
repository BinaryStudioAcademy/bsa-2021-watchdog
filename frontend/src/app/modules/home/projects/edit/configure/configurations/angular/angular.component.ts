import { Component, OnInit } from '@angular/core';
import { BaseConfigurationComponent } from '../base-configuration.component';

@Component({
    selector: 'app-angular',
    templateUrl: './angular.component.html',
    styleUrls: ['../../configure-styles.sass']
})
export class AngularComponent extends BaseConfigurationComponent implements OnInit {
    main: string;
    errorHandler: string;
    appModule: string;

    ngOnInit(): void {
        this.main = `import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
import * as Watchdog from '@watchdog-bsa/watchdog-js';

Watchdog.init('${this.apiKey}');

enableProdMode();
platformBrowserDynamic()
    .bootstrapModule(AppModule)
    .catch(err => { console.error(err); });`;

        this.errorHandler = `import { ErrorHandler, Injectable } from '@angular/core';
import * as Watchdog from '@watchdog-bsa/watchdog-js';
import { throwError } from 'rxjs';

@Injectable()
export class WatchdogErrorHandler implements ErrorHandler {
    handleError(error: any) {
        Watchdog.handleError(error);
        return throwError(error);
    }
}`;
        this.appModule = `import { WatchdogErrorHandler } from './watchdog.interceptor';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

@NgModule({
    declarations: [
        AppComponent
    ],
    providers: [
        { provide: ErrorHandler, useClass: WatchdogErrorHandler },
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }`;
    }
}
