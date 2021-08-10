import { Injectable } from '@angular/core';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = 'users';

    constructor(private http: HttpInternalService) { }

    public getUser(uid: string) {
        return this.http.getRequest<User>(`/${this.apiPrefix}/${uid}`);
    }

    public createUser(newUser: NewUser) {
        const user = newUser;
        if (user.firstName === '') {
            user.firstName = null;
        }
        if (user.lastName === '') {
            user.lastName = null;
        }
        return this.http.postRequest<User>(`/${this.apiPrefix}`, user);
    }

    public updateUser(user: NewUser) {
        return this.http.putRequest<User>(`/${this.apiPrefix}`, user);
    }
}
