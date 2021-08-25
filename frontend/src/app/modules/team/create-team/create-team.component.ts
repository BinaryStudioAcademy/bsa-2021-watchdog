import { regexs } from '@shared/constants/regexs';
import { TeamService } from '@core/services/team.service';
import { uniqueTeamNameValidator } from '@shared/validators/unique-team-name.validator';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
    selector: 'app-create-team',
    templateUrl: './create-team.component.html',
    styleUrls: ['./create-team.component.sass']
})
export class CreateTeamComponent implements OnInit {
    teamGroup: FormGroup;

    constructor(
        private dialogRef: DynamicDialogRef,
        private teamService: TeamService
    ) { }

    ngOnInit(): void {
        this.teamGroup = new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.teamName)
                ],
                [
                    uniqueTeamNameValidator(this.teamService)
                ]
            )
        });
    }

    createTeam() {
        this.dialogRef.close(this.name.value);
    }

    get name() {
        return this.teamGroup.controls.name;
    }
}
