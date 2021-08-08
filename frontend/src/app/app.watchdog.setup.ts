import {ErrorHandler, Injectable} from '@angular/core';
import { HttpInternalService } from '@core/services/http-internal.service';
import { environment } from '@env/environment';

@Injectable({
    providedIn: 'root',
})
export class WatchDogErrorHandler implements ErrorHandler {
    private apiUrl = environment.collectorUrl;

    constructor(private httpService: HttpInternalService) { }

    handleError(e: any) {
        //this.httpService.postFullRequest(`${this.apiUrl}/`, e);
    }
}
