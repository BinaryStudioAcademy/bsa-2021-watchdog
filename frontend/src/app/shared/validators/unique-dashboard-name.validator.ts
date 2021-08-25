import { AbstractControl } from '@angular/forms';
import { DashboardService } from '@core/services/dashboard.service';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { of } from 'rxjs';
import { catchError, delay, map, switchMap, take } from 'rxjs/operators';

export const createDashboardValidator = (existingDashboard: NewDashboard,
    dashboardService: DashboardService, organizationId: number) =>
    (ctrl: AbstractControl) => {
        if (existingDashboard.name === ctrl.value) {
            return of(null);
        }

        return of(ctrl.value).pipe(
            delay(500),
            switchMap(name => dashboardService.isDashboardNameUnique(name, organizationId).pipe(
                map(isUnique =>
                    (isUnique ? null : { notUnique: true })),
                catchError(() => of({ serverError: true }))
            )), take(1)
        );
    };
