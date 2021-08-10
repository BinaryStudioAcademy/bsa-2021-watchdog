import { Observable } from 'rxjs';
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
        private dataService: ShareDataService<Organization>
    ) { }

    getOrganizationsByUserId(userId: number): Observable<Organization[]> {
        return this.httpService.getRequest<Organization[]>(`${this.apiPrefix}/user/${userId}`);
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

    updateProperty(organizationId: number, propName: string, propValue: string) {
        const patchFile: JsonPatch[] = [{ op: 'replace', path: `/${propName}`, value: propValue }];

        return this.httpService.patchFullRequest<Organization>(`${this.apiPrefix}/${organizationId}`, patchFile)
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
