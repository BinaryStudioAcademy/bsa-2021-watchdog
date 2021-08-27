import { throwError } from 'rxjs';
import { ErrorHandler, Injectable } from '@angular/core';
import * as Watchdog from '@watchdog-bsa/watchdog-js';

@Injectable()
export class WatchDogErrorHandler implements ErrorHandler {
    handleError(error: any) {
        Watchdog.handleError(error);
        console.error(error);
        return throwError(error);
    }
}
