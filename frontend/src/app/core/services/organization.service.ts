import { CoreHttpService } from '@core/services/core-http.service';
import { OrganizationSettings } from '@shared/models/organization/organization-settings';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Organization } from '@shared/models/organization/organization';
import { map, tap } from 'rxjs/operators';
import { ShareDataService } from './share-data.service';

@Injectable({
    providedIn: 'root',
})
export class OrganizationService {
    private apiPrefix = '/organizations';

    constructor(
        private httpService: CoreHttpService,
        private dataService: ShareDataService<Organization>
    ) { }

    getOrganizationsByUserId(userId: number): Observable<Organization[]> {
        return this.httpService.getRequest<Organization[]>(`${this.apiPrefix}/user/${userId}`);
    }

    getOrganization(id: number): Observable<Organization> {
        return this.httpService.getRequest<Organization>(`${this.apiPrefix}/${id}`);
    }

    createOrganization(organization: Organization) {
        return this.httpService.postRequest<Organization>(this.apiPrefix, organization);
    }

    updateOrganization(organization: Organization): Observable<Organization> {
        return this.httpService.putRequest<Organization>(`${this.apiPrefix}/${organization.id}`, organization)
            .pipe(tap(response => this.dataService.changeMessage(response)));
    }

    updateSettings(organizationId: number, settings: OrganizationSettings) {
        return this.httpService.putRequest<Organization>(`${this.apiPrefix}/settings/${organizationId}`, settings)
            .pipe(map(organization => {
                this.dataService.changeMessage(organization);
                return organization;
            }));
    }

    isSlugUnique(slug: string): Observable<boolean> {
        return this.httpService.getRequest<boolean>(`${this.apiPrefix}/slug/${slug}`);
    }
}
