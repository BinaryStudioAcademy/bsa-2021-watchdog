import { Component, OnDestroy, OnInit } from '@angular/core';
import { Team } from '@shared/models/team/team';
import { TeamService } from '@core/services/team.service';
import { Subject } from 'rxjs';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateTeamComponent } from '@modules/team/create-team/create-team.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-teams',
    templateUrl: './teams.component.html',
    styleUrls: ['./teams.component.sass', '../team.style.sass'],
    providers: [DialogService]
})
export class TeamsComponent extends BaseComponent implements OnInit, OnDestroy {
    public teamCreated$: Subject<Team> = new Subject<Team>();
    public notifyOtherTeams$: Subject<Team> = new Subject<Team>();
    public notifyMemberTeams$: Subject<Team> = new Subject<Team>();

    createTeamDialog: DynamicDialogRef;
    isLoading: boolean = false;

    //fake
    currentUserId: number = 9;
    currentOrganizationId: number = 1;

    constructor(
        private teamService: TeamService,
        public authService: AuthenticationService,
        public dialogService: DialogService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.currentUserId = this.authService.getUser().id;
    }

    openDialog() {
        this.createTeamDialog = this.dialogService.open(CreateTeamComponent, {
            header: 'Creating team',
            width: '35%',
            showHeader: true,
            baseZIndex: 10000
        });

        this.createTeamDialog.onClose
            .pipe(this.untilThis)
            .subscribe((name: string) => {
                if (name) {
                    this.isLoading = true;
                    this.teamService
                        .createTeam({
                            createdBy: this.currentUserId,
                            organizationId: this.currentOrganizationId,
                            name
                        })
                        .pipe(this.untilThis)
                        .subscribe(response => {
                            this.teamCreated$.next(response.body);
                            this.isLoading = false;
                            this.toastService.success('Team successfully created!', '', 2000);
                        }, error => {
                            this.toastService.error(`${error}`, 'Error', 2000);
                            this.isLoading = false;
                        });
                }
            });
    }

    ngOnDestroy(): void {
        this.teamCreated$.next();
        this.teamCreated$.complete();

        this.notifyOtherTeams$.next();
        this.notifyOtherTeams$.complete();

        this.notifyMemberTeams$.next();
        this.notifyMemberTeams$.complete();
    }
}
