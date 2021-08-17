import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { CoreHttpService } from './core-http.service';
import { clear } from './registration.utils';
import { catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = '/users';

    constructor(
        private httpService: CoreHttpService
    ) { }

    getUserById(id: number): Observable<User> {
        return this.httpService.getRequest<User>(`${this.apiPrefix}/${id}`);
    }

    updateUsersById(id: number, user: User): Observable<User> {
        return this.httpService.putRequest<User>(`${this.apiPrefix}/${id}`, user);
    }

    getUser(uid: string) {
        return this.httpService.getRequest<User>(`${this.apiPrefix}/${uid}`)
            .pipe(
                catchError((error: HttpErrorResponse) => {
                    if (error.status === 404) {
                        return of(null as User);
                    }
                })
            );
    }

    createUser(newUser: NewUser) {
        const user = clear(newUser);
        return this.httpService.postRequest<User>(`${this.apiPrefix}`, user);
    }

    updateUser(user: NewUser) {
        return this.httpService.putRequest<User>(`${this.apiPrefix}`, user);
    }

    searchMembersNotInOrganization(orgId: number, memberEmail: string): Observable<User[]> {
        const url = `organization/${orgId}/notInOrg/${memberEmail !== '' ? `?memberEmail=${memberEmail}` : ''}`;
        return this.httpService.getRequest<User[]>(`${this.apiPrefix}/${url}`);
    }
}
