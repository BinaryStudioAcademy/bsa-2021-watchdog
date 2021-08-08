import { Injectable } from '@angular/core';
import { User } from '@core/models/user';
import { environment } from 'src/environments/environment';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private http: HttpInternalService) { }

    public getUser(uid: string) {
        return this.http.getFullRequest<User>(`${environment.coreUrl}/user/${uid}`);
    }

    public createUser(user: User) {
        return this.http.postFullRequest<User>(`${environment.coreUrl}/user`, user);
    }

    public updateUser(user: User) {
        return this.http.putFullRequest<User>(`${environment.coreUrl}/user`, user);
    }
}
