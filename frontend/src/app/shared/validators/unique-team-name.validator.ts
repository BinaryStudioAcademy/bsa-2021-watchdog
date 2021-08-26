import { TeamService } from '@core/services/team.service';
import { AbstractControl } from '@angular/forms';
import { of } from 'rxjs';
import { catchError, delay, take, map, switchMap } from 'rxjs/operators';

export const uniqueTeamNameValidator = (teamService: TeamService, orgId: number) => (ctrl: AbstractControl) => of(ctrl.value).pipe(
    delay(500),
    switchMap((name) =>
        teamService.isNameUnique(name, orgId)
            .pipe(
                map(isUnique =>
                    (isUnique ? null : { notUnique: true })),
                catchError(() => of({ serverError: true }))
            )), take(1)
);
