import { Injectable } from '@angular/core';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiPrefix = 'users';

    constructor(private http: HttpInternalService) { }

    public getUser(uid: string) {
        return this.http.getRequest<User>(`${environment.coreUrl}/${this.apiPrefix}/${uid}`);
    }

    public createUser(user: NewUser) {
        return this.http.postFullRequest<User>(`${environment.coreUrl}/${this.apiPrefix}`, user)
            .pipe(map(response => response.body));
    }

    public updateUser(user: NewUser) {
        return this.http.putFullRequest<User>(`${environment.coreUrl}/${this.apiPrefix}`, user)
            .pipe(map(response => response.body));
    }
}
