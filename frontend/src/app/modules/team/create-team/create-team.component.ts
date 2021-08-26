import { regexs } from '@shared/constants/regexs';
import { TeamService } from '@core/services/team.service';
import { uniqueTeamNameValidator } from '@shared/validators/unique-team-name.validator';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Organization } from '@shared/models/organization/organization';

@Component({
    selector: 'app-create-team',
    templateUrl: './create-team.component.html',
    styleUrls: ['./create-team.component.sass']
})
export class CreateTeamComponent extends BaseComponent implements OnInit {
    currentOrg: Organization;
    teamGroup: FormGroup;

    constructor(
        private dialogRef: DynamicDialogRef,
        private teamService: TeamService,
        private authService: AuthenticationService,
        private dataService: ShareDataService<Organization>,
        private toastService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.currentOrg = organization;
                this.checkUpdates();
            }, error => {
                this.toastService.error(error, 'Error', 1500);
            });

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
                    uniqueTeamNameValidator(this.teamService, this.currentOrg.id)
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

    private checkUpdates() {
        this.dataService.currentMessage
            .pipe(this.untilThis)
            .subscribe(organization => {
                if (this.currentOrg.id === organization.id) {
                    this.currentOrg = organization;
                }
            });
    }
}
