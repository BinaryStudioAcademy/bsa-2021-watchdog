import { AbstractControl } from "@angular/forms";
import { Observable, of, Subject, throwError } from "rxjs";
import { Injectable } from '@angular/core';
import { Organization } from '@core/models/organization';
import { map } from "rxjs/operators";
import { HttpInternalService } from './http-internal.service';
import { ShareDataService } from "./share-data.service";

@Injectable({
    providedIn: 'root',
})
export class OrganizationService {
    private apiPrefix = '/organizations';

    constructor(
        private httpService: HttpInternalService,
        private dataService: ShareDataService<Organization>
    ) { }

    getOrganization(id: number): Observable<Organization> {
        return this.httpService.getFullRequest<Organization>(`${this.apiPrefix}/${id}`)
            .pipe(map(r => r.body));
    }

    updateOrganization(organization: Organization): Observable<Organization> {
        return this.httpService.putFullRequest<Organization>(`${this.apiPrefix}/${organization.id}`, organization)
            .pipe(map(r => {
                this.dataService.changeMessage(r.body);
                return r.body;
            }));
    }

    isSlugUnique(slug: string): Observable<boolean> {
        return this.httpService.getFullRequest<boolean>(`${this.apiPrefix}/slug/${slug}`)
            .pipe(map(response => {
                console.log(response.body);
                return response.body;
            }));
    }
}
