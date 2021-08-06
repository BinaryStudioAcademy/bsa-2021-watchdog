import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private http: HttpInternalService) { }

    private currentUserSubject: BehaviorSubject<User> = new BehaviorSubject<User>(null);

    public getUserById(id: number): Observable<HttpResponse<User>> {
        return this.http.getFullRequest<User>(`${environment.coreUrl}/user`, { id });
    }

    public updateUser(user: User): Observable<HttpResponse<User>> {
        return this.http.putFullRequest<User>(`${environment.coreUrl}/user`, user);
    }

    public getCurrentUser() {
        return this.getCurrentUserSubject;
    }

    public getAndUpdateUser() {
        this.getUserById(2).subscribe(
            (user) => {
                this.updateUser(user);
            }
        )
    }

    public get getCurrentUserSubject(): User {
        return this.currentUserSubject.value;
    }

}
