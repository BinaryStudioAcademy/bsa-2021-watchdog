import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { HttpInternalService } from './http-internal.service';
import { clear } from './registration.utils';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = '/users';

    constructor(
        private httpService: HttpInternalService
    ) { }

    public getUserById(id: number): Observable<User> {
        return this.httpService.getRequest<User>(`${this.apiPrefix}/${id}`);
    }

    public updateUsersById(id: number, user: User): Observable<User> {
        return this.httpService.putRequest<User>(`${this.apiPrefix}/${user.id}`, user);
    }

    public getUser(uid: string) {
        return this.httpService.getRequest<User>(`/${this.apiPrefix}/${uid}`);
    }

    public createUser(newUser: NewUser) {
        const user = clear(newUser);
        return this.httpService.postRequest<User>(`/${this.apiPrefix}`, user);
    }

    public updateUser(user: NewUser) {
        return this.httpService.putRequest<User>(`/${this.apiPrefix}`, user);
    }
}
