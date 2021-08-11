import { AbstractControl } from "@angular/forms";
import { OrganizationService } from "@core/services/organization.service";
import { of } from "rxjs";
import { catchError, delay, map, switchMap, take } from "rxjs/operators";
import { Organization } from "@shared/models/organization/organization";

export const uniqueSlugValidator = (existingOrg: Organization, orgService: OrganizationService) => (ctrl: AbstractControl) => {
    if (existingOrg.organizationSlug === ctrl.value) {
        return of(null);
    }

    return of(ctrl.value).pipe(
        delay(500),
        switchMap(slug => orgService.isSlugUnique(ctrl.value).pipe(
            map(isUnique =>
                (isUnique ? null : { notUnique: true })),
            catchError(() => of({ serverError: true }))
        )), take(1));
}
