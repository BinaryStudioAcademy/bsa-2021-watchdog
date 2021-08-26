import { regexs } from '@shared/constants/regexs';
import { uniqueTeamNameValidator } from '@shared/validators/unique-team-name.validator';
import { TeamService } from '@core/services/team.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { Team } from '@shared/models/teams/team';
import { of } from 'rxjs';
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Organization } from '@shared/models/organization/organization';

@Component({
    selector: 'app-team-settings',
    templateUrl: './team-settings.component.html',
    styleUrls: ['./team-settings.component.sass']
})
export class TeamSettingsComponent extends BaseComponent implements OnInit {
    @Input() team: Team;
    @Input() parentForm: FormGroup;
    currentOrgId: number;

    constructor(
        private teamService: TeamService,
        private authService: AuthenticationService,
        private dataService: ShareDataService<Organization>,
        private toastService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit() {
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.currentOrgId = organization.id;
            }, error => {
                this.toastService.error(error, 'Error', 1500);
            });

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
        return uniqueTeamNameValidator(this.teamService, this.currentOrgId)(ctrl);
    };

    get name() {
        return this.parentForm.controls.name;
    }
}
