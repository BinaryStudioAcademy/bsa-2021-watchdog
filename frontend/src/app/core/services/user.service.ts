import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { CoreHttpService } from './core-http.service';
import { clear } from './registration.utils';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = '/users';

    constructor(
        private httpService: CoreHttpService
    ) { }

    public getUserById(id: number): Observable<User> {
        return this.httpService.getRequest<User>(`${this.apiPrefix}/${id}`);
    }

    public updateUsersById(id: number, user: User): Observable<User> {
        return this.httpService.putRequest<User>(`${this.apiPrefix}/${id}`, user);
    }

    public getUser(uid: string) {
        return this.httpService.getRequest<User>(`${this.apiPrefix}/${uid}`)
            .pipe(
                catchError((error: string) => {
                    if (error.includes("Error Code: 404")) {
                        return of(null as User);
                    }
                })
            );
    }

    public createUser(newUser: NewUser) {
        const user = clear(newUser);
        return this.httpService.postRequest<User>(`${this.apiPrefix}`, user);
    }

    public updateUser(user: NewUser) {
        return this.httpService.putRequest<User>(`${this.apiPrefix}`, user);
    }
}
