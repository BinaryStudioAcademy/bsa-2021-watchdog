import { Injectable } from '@angular/core';
import {
    HttpHandler,
    HttpInterceptor,
    HttpErrorResponse,
    HttpRequest,
    HttpEvent,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ErrorsService } from '@core/services/errors.service';

@Injectable({
    providedIn: 'root',
})
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private errorsService: ErrorsService) { }

    handleError(error: HttpErrorResponse) {
        return throwError(error);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        return next.handle(req).pipe(
            retry(1),
            catchError((error: HttpErrorResponse) => {
                this.errorsService.log(error);
                return throwError(error);
            })
        );
    }
}
