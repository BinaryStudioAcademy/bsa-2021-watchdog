import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Organization } from '@shared/models/organization/organization';
import { tap } from 'rxjs/operators';
import { JsonPatch } from '@shared/models/json-patch';
import { CoreHttpService } from './core-http.service';
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

    updateProperty(organizationId: number, propName: string, propValue: string) {
        const patchFile: JsonPatch[] = [{ op: 'replace', path: `/${propName}`, value: propValue }];

        return this.httpService.patchRequest<Organization>(`${this.apiPrefix}/${organizationId}`, patchFile)
            .pipe(tap(response => this.dataService.changeMessage(response)));
    }

    isSlugUnique(slug: string): Observable<boolean> {
        return this.httpService.getRequest<boolean>(`${this.apiPrefix}/slug/${slug}`);
    }
}
