import { Injectable } from '@angular/core';
import { UserUpdateDto } from '@core/models/userUpdate';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private httpService: HttpInternalService) { }

    public getUserById(id: number) {
        return this.httpService.getRequest<User>(`${environment.coreUrl}/user`, { id });
    }

    public updateUser(user: UserUpdateDto) {
        return this.httpService.putRequest<UserUpdateDto>(`${environment.coreUrl}/user`, user);
    }
}
