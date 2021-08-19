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

@Component({
    selector: 'app-team-info',
    templateUrl: './team-info.component.html',
    styleUrls: ['./team-info.component.sass']
})
export class TeamInfoComponent extends BaseComponent implements OnInit {
    team: Team;
    isSettings: boolean = false;
    isLoading: boolean = false;

    parentForm: FormGroup = new FormGroup({});

    @ViewChild('saveBut') saveButton: ElementRef<HTMLButtonElement>;

    constructor(
        private activatedRoute: ActivatedRoute,
        private teamService: TeamService,
        private router: Router,
        private toastService: ToastNotificationService,
        private confirmService: ConfirmWindowService
    ) { super(); }

    ngOnInit() {
        this.isLoading = true;
        this.activatedRoute.paramMap
            .pipe(this.untilThis)
            .subscribe(param => {
                this.teamService.getTeam(+param.get('id'))
                    .pipe(this.untilThis)
                    .subscribe(team => {
                        this.team = team;
                        this.isLoading = false;
                    }, error => {
                        this.toastService.error(error);
                        this.isLoading = false;
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
        this.isLoading = true;
        const teamValues: UpdateTeam = { ...this.parentForm.value };
        this.teamService.updateTeam(this.team.id, teamValues)
            .pipe(this.untilThis)
            .subscribe(updatedTeam => {
                Object.assign(this.team, updatedTeam);
                this.isLoading = false;
                this.saveButton.nativeElement.disabled = true;
                this.toastService.success('Team was saved!');
            }, error => {
                this.isLoading = false;
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
                this.isLoading = true;
                this.teamService.removeTeam(this.team.id)
                    .pipe(this.untilThis)
                    .subscribe(() => {
                        this.isLoading = false;
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
