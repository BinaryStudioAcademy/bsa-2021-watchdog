import { Injectable } from '@angular/core';
import {
    HttpHandler,
    HttpInterceptor,
    HttpErrorResponse,
    HttpRequest,
    HttpEvent,
    HttpResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';
import { ErrorsService } from '@core/collecting-errors/services/errors.service';
import { BaseService } from '../services/base.service';
import { AjaxBreadcrumb } from '../models/ajax-breadcrumb';

@Injectable({
    providedIn: 'root',
})
export class ErrorInterceptor extends BaseService implements HttpInterceptor {
    constructor(private errorsService: ErrorsService) {
        super();
     }

    handleError(error: HttpErrorResponse) {
        return throwError(error);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            retry(1),
            tap(event => {
                if (event instanceof HttpResponse) {
                    const response: HttpResponse<any> = event;
                    this.eventSource.next(new AjaxBreadcrumb(req.url, req.method, req.body, response.status, response.body));
                }
            }),
            catchError((error: HttpErrorResponse) => {
                this.errorsService.log(error);
                let errorMessage: string;
                if (error.error instanceof ErrorEvent) {
                    errorMessage = `Error: ${error.error.message}`;
                } else {
                    errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
                }
                return throwError(errorMessage);
            })
        );
    }
}
