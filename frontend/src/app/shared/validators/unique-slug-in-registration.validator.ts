import { AbstractControl } from '@angular/forms';
import { OrganizationService } from '@core/services/organization.service';
import { of } from 'rxjs';
import { catchError, delay, map, switchMap, take } from 'rxjs/operators';
import { NewOrganizationsWithSlug } from '@shared/models/organization/newOrganizationsWithSlug';


export const uniqueSlugValidatorInRegistration = (existingOrg: NewOrganizationsWithSlug, orgService: OrganizationService) => (ctrl: AbstractControl) => {
    if (existingOrg.organizationSlug === ctrl.value) {
        return of(null);
    }

    return of(ctrl.value).pipe(
        delay(500),
        switchMap(slug => orgService.isSlugUnique(slug).pipe(
            map(isUnique =>
                (isUnique ? null : { notUnique: true })),
            catchError(() => of({ serverError: true }))
        )), take(1)
    );
};
