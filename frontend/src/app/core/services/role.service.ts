import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Role } from '@shared/models/role/role';
import { CoreHttpService } from './core-http.service';

@Injectable({
    providedIn: 'root',
})
export class RoleService {
    private apiPrefix = '/roles';

    constructor(private httpService: CoreHttpService) { }

    getRoles(): Observable<Role[]> {
        return this.httpService.getRequest<Role[]>(`${this.apiPrefix}`);
    }
}
