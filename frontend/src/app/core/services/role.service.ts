import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { Role } from '@shared/models/role/role';
import { CoreHttpService } from './core-http.service';
import { tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class RoleService {
    private apiPrefix = '/roles';

    constructor(private httpService: CoreHttpService) { }

    private static roles: Role[];

    getRoles(): Observable<Role[]> {
        if (!RoleService.roles) {
            return this.httpService.getRequest<Role[]>(`${this.apiPrefix}`)
                .pipe(tap(roles => {
                    RoleService.roles = roles;
                }));
        }
        return of(RoleService.roles);
    }
}
