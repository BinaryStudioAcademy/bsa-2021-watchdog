import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Organization } from '@core/models/organization';
import { map } from 'rxjs/operators';
import { HttpInternalService } from './http-internal.service';
import { Role } from '@core/models/role';

@Injectable({
    providedIn: 'root',
})
export class RoleService {
    private apiPrefix = '/roles';

    constructor(private httpService: HttpInternalService) { }

    getRoles(): Observable<Role> {
        return this.httpService.getFullRequest<Role>(`${this.apiPrefix}`)
            .pipe(map(r => r.body));
    }
}
