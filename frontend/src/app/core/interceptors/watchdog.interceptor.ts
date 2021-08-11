import { ErrorHandler, Injectable } from '@angular/core';
import { HttpInternalService } from '@core/services/http-internal.service';
import { ErrorsService } from '@core/services/errors.service';

@Injectable()
export class WatchDogErrorHandler implements ErrorHandler {
    constructor(private httpService: HttpInternalService, private errorsService: ErrorsService) { }

    handleError(error: any) {
        this.errorsService.log(error);
        console.error(error);
    }
}
