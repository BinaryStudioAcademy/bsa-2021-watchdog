import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthUser } from '@core/models/auth/auth-user';
import { UserLoginDto } from '@core/models/auth/user-login';
import { UserRegisterDto } from '@core/models/auth/user-register';
import { User } from '@core/models/user';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserService } from './user.service';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private currentUserSubject: BehaviorSubject<AuthUser>;
    public currentUser: Observable<AuthUser>;
    private user: User;

    constructor(private http: HttpClient, private userService: UserService) {
        this.clearUser();
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

    public getUser(): User {
        return this.currentUserSubject.value?.user;
    }

    // public getUsers() {
    //     return this.user
    //         ? of(this.user)
    //         : this.userService.getUserById(10).pipe(
    //             map((resp) => {
    //                 this.user = resp.body;
    //                 return this.user;
    //             })
    //         );
    // }

    public setUser(user: User) {
        this.currentUserSubject.value.user = user;
        localStorage.setItem('currentUser', JSON.stringify(user));
    }

    private clearUser() {
        localStorage.removeItem('currentUser');
    }
}
