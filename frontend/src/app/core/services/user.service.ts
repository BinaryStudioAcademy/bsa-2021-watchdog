import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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

    public updateUser(user: User): Observable<HttpResponse<User>> {
        return this.http.putFullRequest<User>(`${environment.coreUrl}/user`, user);
    }

}
