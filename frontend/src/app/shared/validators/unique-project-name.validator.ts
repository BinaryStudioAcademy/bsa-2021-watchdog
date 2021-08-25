import { AbstractControl } from '@angular/forms';
import { ProjectService } from '@core/services/project.service';
import { NewProject } from '@shared/models/projects/new-project';
import { of } from 'rxjs';
import { catchError, delay, map, switchMap, take } from 'rxjs/operators';

export const uniqueProjectNameValidator = (existingProject: NewProject, projectService: ProjectService,
    organizationId: number) =>
    (ctrl: AbstractControl) => {
        if (existingProject.name === ctrl.value) {
            return of(null);
        }

        return of(ctrl.value).pipe(
            delay(500),
            switchMap(name => projectService.isProjectNameUnique(name, organizationId).pipe(
                map(isUnique =>
                    (isUnique ? null : { notUnique: true })),
                catchError(() => of({ serverError: true }))
            )), take(1)
        );
    };
