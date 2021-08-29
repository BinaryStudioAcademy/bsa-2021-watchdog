import { AbstractControl } from '@angular/forms';
import { OrganizationService } from '@core/services/organization.service';
import { of } from 'rxjs';
import { catchError, delay, map, switchMap, take } from 'rxjs/operators';

export const existOrganization = (orgService: OrganizationService) => (ctrl: AbstractControl) =>
    of(ctrl.value).pipe(
        delay(500),
        switchMap(slug => orgService.isOrganizationExist(slug).pipe(
            map(isExist =>
                (isExist ? null : { doesntExist: true })),
            catchError(() => of({ serverError: true }))
        )), take(1)
    );
