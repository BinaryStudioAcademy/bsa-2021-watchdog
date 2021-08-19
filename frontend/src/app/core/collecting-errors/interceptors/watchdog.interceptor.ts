import { ErrorHandler, Injectable } from '@angular/core';
import { ErrorsService } from '@core/collecting-errors/services/errors.service';

@Injectable()
export class WatchDogErrorHandler implements ErrorHandler {
    constructor(private errorsService: ErrorsService) { }

    handleError(error: any) {
        this.errorsService.log(error);
        console.error(error);
    }
}
