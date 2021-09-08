import { AuthenticationService } from '@core/services/authentication.service';
import { zip } from 'rxjs';
import { FormGroup } from '@angular/forms';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { TeamService } from '@core/services/team.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { PrimeIcons } from 'primeng/api';
import { UpdateTeam } from '@shared/models/teams/update-team';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-team-info',
    templateUrl: './team-info.component.html',
    styleUrls: ['./team-info.component.sass']
})
export class TeamInfoComponent extends BaseComponent implements OnInit {
    team: Team;
    isSettings: boolean = false;
    loading: boolean;
    notFound: boolean;
    parentForm: FormGroup = new FormGroup({});

    @ViewChild('saveBut') saveButton: ElementRef<HTMLButtonElement>;

    constructor(
        private activatedRoute: ActivatedRoute,
        private teamService: TeamService,
        private router: Router,
        private toastService: ToastNotificationService,
        private confirmService: ConfirmWindowService,
        private spinnerService: SpinnerService,
        private authService: AuthenticationService
    ) { super(); }

    ngOnInit() {
        this.spinnerService.show(true);
        this.loading = true;
        this.activatedRoute.paramMap
            .pipe(this.untilThis)
            .subscribe(param => {
                console.warn('here1');
                zip(this.teamService.getTeam(param.get('id')), this.authService.getOrganization())
                    .pipe(this.untilThis)
                    .subscribe(([team, organization]) => {
                        console.warn('here');
                        if (team.organizationId !== organization.id) {
                            this.notFound = true;
                        } else {
                            this.team = team;
                        }
                        this.loading = false;
                        this.spinnerService.hide();
                    }, error => {
                        this.toastService.error(error);
                        this.notFound = true;
                        this.loading = false;
                        this.spinnerService.hide();
                    });
            });

        this.parentForm.statusChanges.subscribe(() => { this.checkSaveStatus(); });
    }

    resetButtonsState(event: any) {
        this.isSettings = event.index === 2;
    }

    reset() {
        this.parentForm.reset(this.team);
    }

    saveTeam() {
        this.spinnerService.show(true);
        const teamValues: UpdateTeam = { ...this.parentForm.value };
        this.teamService.updateTeam(this.team.id, teamValues)
            .pipe(this.untilThis)
            .subscribe(updatedTeam => {
                Object.assign(this.team, updatedTeam);
                this.spinnerService.hide();
                this.saveButton.nativeElement.disabled = true;
                this.toastService.success('Team was saved!');
            }, error => {
                this.spinnerService.hide();
                this.toastService.error(error);
            });
    }

    removeTeam() {
        this.confirmService.confirm({
            title: `Remove Team #${this.team.name}`,
            message: 'Are you sure, you want to delete this team?',
            icon: PrimeIcons.BAN,
            acceptButton: { label: 'Yes', class: 'p-button-outlined p-button-danger' },
            cancelButton: { label: 'No', class: 'p-button-outlined p-button-secondary' },
            accept: () => {
                this.spinnerService.show(true);
                this.teamService.removeTeam(this.team.id)
                    .pipe(this.untilThis)
                    .subscribe(() => {
                        this.spinnerService.hide();
                        this.router.navigate(['home/teams']).then(() => {
                            this.toastService.success('Team was removed!');
                        });
                    }, error => {
                        this.toastService.error(error);
                    });
            }
        });
    }

    checkSaveStatus() {
        if (this.parentForm.untouched || this.parentForm.pending || this.parentForm.invalid) {
            this.saveButton.nativeElement.disabled = true;
        }
        if (this.parentForm.valid && (this.parentForm.touched || this.parentForm.dirty)) {
            const unsavedChangesProps = Object.keys(this.parentForm.controls)
                .filter(key =>
                    this.parentForm.controls[key].value !== this.team[key]);

            if (unsavedChangesProps.length > 0) this.saveButton.nativeElement.disabled = false;
            else this.saveButton.nativeElement.disabled = true;
        }
    }
}
