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

    constructor(private dialogRef: DynamicDialogRef) { }

    ngOnInit(): void {
        this.teamGroup = new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                ]
            )
        });
    }

    createTeam() {
        const name = <string> this.teamGroup.controls.name.value;
        this.dialogRef.close(name.split(' ').join('-').toLocaleLowerCase());
    }
}
