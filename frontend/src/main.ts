import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import * as Watchdog from '@watchdog-bsa/watchdog-js';

const apiKey = '6DB23407-EE62-431C-87E1-5585FF54562E';

if (environment.production) {
    Watchdog.init(apiKey, false);
    enableProdMode();
} else {
    Watchdog.init(apiKey, false, 'http://localhost:5090/issues/');
}

platformBrowserDynamic().bootstrapModule(AppModule)
    .catch(err => console.error(err));
