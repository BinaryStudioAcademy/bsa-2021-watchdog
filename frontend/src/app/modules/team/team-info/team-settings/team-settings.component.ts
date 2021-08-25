import { regexs } from '@shared/constants/regexs';
import { uniqueTeamNameValidator } from '@shared/validators/unique-team-name.validator';
import { TeamService } from '@core/services/team.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { Team } from '@shared/models/teams/team';
import { of } from 'rxjs';

@Component({
    selector: 'app-team-settings',
    templateUrl: './team-settings.component.html',
    styleUrls: ['./team-settings.component.sass']
})
export class TeamSettingsComponent implements OnInit {
    @Input() team: Team;
    @Input() parentForm: FormGroup;

    constructor(private teamService: TeamService) { }

    ngOnInit() {
        this.parentForm.addControl('name', new FormControl(this.team.name, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
            Validators.pattern(regexs.teamName),
        ], [
            this.teamNameValidator
        ]));
    }

    teamNameValidator = (ctrl: AbstractControl) => {
        if (this.team.name === ctrl.value) {
            return of(null);
        }
        return uniqueTeamNameValidator(this.teamService)(ctrl);
    };

    get name() {
        return this.parentForm.controls.name;
    }
}
