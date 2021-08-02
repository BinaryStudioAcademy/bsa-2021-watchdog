import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private http: HttpInternalService) { }

    public updateUser(user: User) {
        return this.http.putFullRequest<User>(`${environment.coreUrl}/user`, user);
    }
}
