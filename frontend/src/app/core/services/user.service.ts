import { Injectable } from '@angular/core';
import { UserUpdateDto } from '@core/models/userUpdate';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { HttpInternalService } from './http-internal.service';
import { ShareDataService } from './share-data.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = '/user';
    private apiPrefixRegister = 'users';

    constructor(
        private httpService: HttpInternalService,
        private dataService: ShareDataService<User>
    ) { }

    public getUserById(id: number): Observable<User> {
        return this.httpService.getFullRequest<User>(`${this.apiPrefix}/${id}`)
            .pipe(map(response => response.body));
    }

    public updateUsersById(id: number, user: UserUpdateDto): Observable<UserUpdateDto> {
        return this.httpService.putFullRequest<User>(`${this.apiPrefix}/${user.id}`, user)
            .pipe(map(response => {
                this.dataService.changeMessage(response.body);
                return response.body;
            }));
    }

    public getUser(uid: string) {
        return this.httpService.getRequest<User>(`/${this.apiPrefixRegister}/${uid}`);
    }

    public createUser(user: NewUser) {
        return this.httpService.postRequest<User>(`/${this.apiPrefixRegister}`, user);
    }

    public updateUser(user: NewUser) {
        return this.httpService.putRequest<User>(`/${this.apiPrefixRegister}`, user);
    }
}
