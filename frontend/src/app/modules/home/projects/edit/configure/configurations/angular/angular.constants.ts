export const appModule = `import { WatchdogErrorHandler } from './watchdog.interceptor';
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

export const errorHandler = `import { ErrorHandler, Injectable } from '@angular/core';
import * as Watchdog from '@watchdog-bsa/watchdog-js';
import { throwError } from 'rxjs';

@Injectable()
export class WatchdogErrorHandler implements ErrorHandler {
    handleError(error: any) {
        Watchdog.handleError(error);
        return throwError(error);
    }
}`;

export const main = (apiKey: string) => `import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
import * as Watchdog from '@watchdog-bsa/watchdog-js';

Watchdog.init('${apiKey}');

enableProdMode();
platformBrowserDynamic()
    .bootstrapModule(AppModule)
    .catch(err => { console.error(err); });`;
