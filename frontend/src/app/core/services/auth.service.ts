import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthUser } from '@core/models/auth/auth-user';
import { UserLoginDto } from '@core/models/auth/user-login';
import { UserRegisterDto } from '@core/models/auth/user-register';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private currentUserSubject: BehaviorSubject<AuthUser>;
    public currentUser: Observable<AuthUser>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<AuthUser>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    login(userLogin: UserLoginDto): Observable<AuthUser> {
        return this.http.post<AuthUser>(`${environment.coreUrl}/user/login`, userLogin)
            .pipe(map(user => {
                if (user.token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.currentUserSubject.next(user);
                }
                return user;
            }));
    }

    register(userRegister: UserRegisterDto): Observable<AuthUser> {
        return this.http.post<AuthUser>(`${environment.coreUrl}/user/register`, userRegister)
        .pipe(map(user => {
            if (user.token) {
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
            }
            return user;
        }));
    }

    logout() {
        this.clearUser();
        this.currentUserSubject?.next(null);
    }

    isAuthorized(): boolean {
        return !!this.currentUserSubject.value;
    }

    private clearUser() {
        localStorage.removeItem('currentUser');
    }
}
