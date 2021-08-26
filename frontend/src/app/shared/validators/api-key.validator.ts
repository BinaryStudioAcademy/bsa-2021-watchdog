import { AbstractControl } from '@angular/forms';
import { of } from 'rxjs';
import { catchError, delay, map, switchMap, take } from 'rxjs/operators';
import { ProjectService } from '@core/services/project.service';

export const uniqueApiKeyValidator = (projectService: ProjectService) => (ctrl: AbstractControl) =>
    of(ctrl.value).pipe(
        delay(500),
        switchMap(apiKey => projectService.isApiKeyUnique(apiKey).pipe(
            map(isUnique =>
                (isUnique ? null : { notUnique: true })),
            catchError(() => of({ serverError: true }))
        )), take(1)
    );
