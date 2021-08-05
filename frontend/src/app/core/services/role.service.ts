import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Role } from '@shared/models/role/role';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root',
})
export class RoleService {
    private apiPrefix = '/roles';

    constructor(private httpService: HttpInternalService) { }

    getRoles(): Observable<Role> {
        return this.httpService.getFullRequest<Role>(`${this.apiPrefix}`)
            .pipe(map(response => response.body));
    }
}
