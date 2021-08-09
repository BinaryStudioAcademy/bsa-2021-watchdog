import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    public readonly routePrefix = '/user';

    constructor(private httpService: HttpInternalService) { }

    public updateUser(user: User) {
        return this.httpService.putFullRequest<User>(`${this.routePrefix}`, user);
    }
}
