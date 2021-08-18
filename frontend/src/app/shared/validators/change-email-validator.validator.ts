import { AbstractControl } from '@angular/forms';
import { UserService } from '@core/services/user.service';
import { User } from '@shared/models/user/user';
import { of } from 'rxjs';
import { catchError, delay, map, switchMap, take } from 'rxjs/operators';

export const changeEmailValidator = (existingUser: User, userService: UserService) =>
    (ctrl: AbstractControl) => {
        if (existingUser.email === ctrl.value) {
            return of(null);
        }

        return of(ctrl.value).pipe(
            delay(500),
            switchMap(email => userService.isEmailUnique(email).pipe(
                map(isUnique =>
                    (isUnique ? null : { notUnique: true })),
                catchError(() => of({ serverError: true }))
            )), take(1)
        );
    };
