import { OrganizationSettings } from "./../../shared/models/organization/organization-settings";
import { AuthenticationService } from "./authentication.service";
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { Organization } from '@shared/models/organization/organization';
import { map } from 'rxjs/operators';
import { JsonPatch } from '@shared/models/json-patch';
import { HttpInternalService } from './http-internal.service';
import { ShareDataService } from './share-data.service';

@Injectable({
    providedIn: 'root',
})
export class OrganizationService {
    private apiPrefix = '/organizations';

    constructor(
        private httpService: HttpInternalService,
        private dataService: ShareDataService<Organization>,
        private authService: AuthenticationService
    ) { }

    //TODO: for now you get just first organization
    getCurrentOrganization(): Observable<Organization> {
        const user = this.authService.getUser();
        return this.httpService.getRequest<Organization[]>(`${this.apiPrefix}/user/${user.id}`)
            .pipe(map(organizations => organizations[0]));
    }

    getOrganization(id: number): Observable<Organization> {
        return this.httpService.getFullRequest<Organization>(`${this.apiPrefix}/${id}`)
            .pipe(map(response => response.body));
    }

    createOrganization(organization: Organization) {
        return this.httpService.postFullRequest<Organization>(this.apiPrefix, organization)
            .pipe(map(response => response.body));
    }

    updateOrganization(organization: Organization): Observable<Organization> {
        return this.httpService.putFullRequest<Organization>(`${this.apiPrefix}/${organization.id}`, organization)
            .pipe(map(response => {
                this.dataService.changeMessage(response.body);
                return response.body;
            }));
    }

    updateSettings(organizationId: number, settings: OrganizationSettings) {
        return this.httpService.putFullRequest<Organization>(`${this.apiPrefix}/settings/${organizationId}`, settings)
            .pipe(map(response => {
                this.dataService.changeMessage(response.body);
                return response.body;
            }));
    }

    isSlugUnique(slug: string): Observable<boolean> {
        return this.httpService.getFullRequest<boolean>(`${this.apiPrefix}/slug/${slug}`)
            .pipe(map(response => response.body));
    }
}
