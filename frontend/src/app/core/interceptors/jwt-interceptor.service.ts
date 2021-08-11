import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from '@core/services/authentication.service';
import { Observable, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class JwtInterceptorService implements HttpInterceptor {
    private tokenRequest$: Observable<string>;

    constructor(
        private authService: AuthenticationService
    ) { }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        if (!this.authService.isAuthenticated()
      || request.url.includes('/signin')
      || request.url.includes('/signon')
        ) {
            return next.handle(request);
        }

        if (!this.tokenRequest$) {
            this.tokenRequest$ = this.authService.getJwToken();
        }

        return this.tokenRequest$
            .pipe(
                switchMap(token => {
                    this.tokenRequest$ = null;
                    return next.handle(this.setToken(request, token));
                }),
                catchError((error: HttpErrorResponse) => {
                    if (error.status !== 401) {
                        return throwError(error);
                    }
                    if (!this.tokenRequest$) {
                        this.tokenRequest$ = this.authService.getJwToken();
                    }
                    return this.tokenRequest$
                        .pipe(
                            switchMap(token => {
                                this.tokenRequest$ = null;
                                return next.handle(this.setToken(request, token));
                            })
                        );
                })
            );
    }

    private setToken = (request: HttpRequest<unknown>, token: string) =>
        (token
            ? request.clone({ setHeaders: { Authorization: `Bearer ${token}` } })
            : request);
}
