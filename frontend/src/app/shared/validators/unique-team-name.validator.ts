import { Team } from "@shared/models/team/team";
import { TeamService } from "@core/services/team.service";
import { AbstractControl } from "@angular/forms";
import { of } from "rxjs";
import { catchError, delay, take, map, switchMap } from "rxjs/operators";

export const uniqueTeamNameValidator = (existingTeam: Team, teamService: TeamService) => (ctrl: AbstractControl) => {
    if (existingTeam.name === ctrl.value) return of(null);

    return of(ctrl.value).pipe(
        delay(500),
        switchMap((name) =>
            teamService.isNameUnique(name)
                .pipe(
                    map(isUnique =>
                        isUnique ? null : { notUnique: true }),
                    catchError(error => of({ serverError: true })))
        ), take(1));
}
