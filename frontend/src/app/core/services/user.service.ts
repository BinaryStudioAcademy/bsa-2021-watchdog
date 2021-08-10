import { Injectable } from '@angular/core';
import { UserUpdateDto } from '@core/models/userUpdate';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpInternalService } from './http-internal.service';
import { ShareDataService } from './share-data.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = '/user';

    constructor(
        private httpService: HttpInternalService,
        private dataService: ShareDataService<User>
    ) { }

    public getUserById(id: number): Observable<User> {
        return this.httpService.getFullRequest<User>(`${this.apiPrefix}/${id}`)
            .pipe(map(response => response.body));
    }

    public updateUser(user: UserUpdateDto): Observable<UserUpdateDto> {
        return this.httpService.putFullRequest<User>(`${this.apiPrefix}`, user)
            .pipe(map(response => {
                this.dataService.changeMessage(response.body);
                return response.body;
            }));
    }

    public updateUsersById(id: number, user: UserUpdateDto): Observable<UserUpdateDto> {
        return this.httpService.putFullRequest<User>(`${this.apiPrefix}/${user.id}`, user)
            .pipe(map(response => {
                this.dataService.changeMessage(response.body);
                return response.body;
            }));
    }
}
