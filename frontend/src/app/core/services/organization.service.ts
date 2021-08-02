import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Organization } from '@core/models/organization';
import { map } from 'rxjs/operators';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root',
})
export class OrganizationService {
    apiPrefix = '/organizations';

    constructor(private httpService: HttpInternalService) { }

    getOrganization(id: number): Observable<Organization> {
        return this.httpService.getFullRequest<Organization>(`${this.apiPrefix}/${id}`)
            .pipe(map(r => r.body));
    }
}
