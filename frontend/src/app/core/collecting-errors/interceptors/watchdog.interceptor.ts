import { ErrorHandler, Injectable } from '@angular/core';
import { CoreHttpService } from '@core/services/core-http.service';
import { ErrorsService } from '@core/collecting-errors/services/errors.service';

@Injectable()
export class WatchDogErrorHandler implements ErrorHandler {
    constructor(private httpService: CoreHttpService, private errorsService: ErrorsService) { }

    handleError(error: any) {
        this.errorsService.log(error);
        console.error(error);
    }
}
