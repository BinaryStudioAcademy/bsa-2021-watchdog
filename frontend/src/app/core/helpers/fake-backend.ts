import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse, HttpHandler, HttpEvent, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { delay, mergeMap, materialize, dematerialize } from 'rxjs/operators';
import { User } from '@core/models/user';
import { AuthUser } from '@core/models/auth/auth-user';

const users: User[] = [{ id: 1, email: 'test@test', password: 'test', userName: 'User' }];

@Injectable({
    providedIn: 'root'
})
export class FakeBackendInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const { url, method, body } = request;

        function authenticate(): Observable<HttpResponse<AuthUser>> | Observable<HttpResponse<string>> {
            const { email, password } = body;
            const user = users.find(x => x.email === email && x.password === password);
            if (!user) {
                return of(new HttpResponse({
                    status: 404, body: 'Email or password is incorrect'
                }));
            }

            return of(new HttpResponse({
                status: 200,
                body: {
                    user: {
                        id: user.id,
                        password: user.password,
                        email: user.email,
                        userName: user.userName
                    },
                    token: 'fake-token'
                }
            }));
        }

        function handleRoute() {
            switch (true) {
                case url.endsWith('/user/login') && method === 'POST':
                    return authenticate();
                default:
                    return next.handle(request);
            }
        }
        return of(null)
            .pipe(mergeMap(handleRoute))
            .pipe(materialize())
            .pipe(delay(500))
            .pipe(dematerialize());
    }
}

export const fakeBackendProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: FakeBackendInterceptor,
    multi: true
};
