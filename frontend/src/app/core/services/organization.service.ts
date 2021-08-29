import { NewOrganization } from '../../shared/models/organization/new-organization';
import { CoreHttpService } from '@core/services/core-http.service';
import { OrganizationSettings } from '@shared/models/organization/organization-settings';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { Organization } from '@shared/models/organization/organization';
import { map, share, tap } from 'rxjs/operators';
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

    private static organization: Organization;

    clearOrganization() {
        OrganizationService.organization = null;
        localStorage.removeItem('currentOrganizationId');
    }

    getCurrentOrganization(id: number) {
        if (!OrganizationService.organization) {
            return this.getOrganizationsByUserId(id)
                .pipe(
                    tap(organizations => {
                        const radix = 10;
                        const currentOrganizationId = parseInt(localStorage.getItem('currentOrganizationId'), radix);
                        const organization = organizations.find(o => o.id === currentOrganizationId) ?? organizations[0];
                        this.setCurrentOrganization(organization);
                    }),
                    map(() => OrganizationService.organization)
                );
        }
        return of(OrganizationService.organization);
    }

    setCurrentOrganization(organization: Organization) {
        localStorage.setItem('currentOrganizationId', organization.id.toString());
        OrganizationService.organization = organization;
    }

    private orgRequest$: Observable<Organization[]>;

    getOrganizationsByUserId(userId: number): Observable<Organization[]> {
        if (this.orgRequest$) {
            return this.orgRequest$;
        }
        this.orgRequest$ = this.httpService.getRequest<Organization[]>(`${this.apiPrefix}/user/${userId}`)
            .pipe(
                tap(() => {
                    this.orgRequest$ = null;
                }),
                share()
            );
        return this.orgRequest$;
    }

    getOrganization(id: number): Observable<Organization> {
        return this.httpService.getRequest<Organization>(`${this.apiPrefix}/${id}`);
    }

    getDafaultOrganizationByUserId(userId: number): Observable<Organization> {
        return this.httpService.getRequest<Organization>(`${this.apiPrefix}/default/user/${userId}`);
    }

    createOrganization(organization: NewOrganization) {
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

    deleteOrganization(organizationId: number) {
        return this.httpService.deleteRequest(`${this.apiPrefix}/${organizationId}`);
    }

    isSlugUnique(slug: string): Observable<boolean> {
        return this.httpService.getRequest<boolean>(`${this.apiPrefix}/slug/${slug}`);
    }
}
