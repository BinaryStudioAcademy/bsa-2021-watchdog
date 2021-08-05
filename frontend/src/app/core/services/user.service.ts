import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private http: HttpInternalService) { }

    public getUserById(id: number) {
        return this.http.getFullRequest<User>(`${environment.coreUrl}/user`, { id });
    }

    public updateUser(user: User) {
        return this.http.putFullRequest<User>(`${environment.coreUrl}/user`, user);
    }

    public copyUser({ id, firstName, lastName, email, avatar, password }: User) {
        return {
            id,
            firstName,
            lastName,
            email,
            avatar,
            password
        };
    }
}
