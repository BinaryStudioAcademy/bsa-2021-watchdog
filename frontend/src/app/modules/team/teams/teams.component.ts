import { Organization } from '@shared/models/organization/organization';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { TeamService } from '@core/services/team.service';
import { Subject } from 'rxjs';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateTeamComponent } from '@modules/team/create-team/create-team.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { User } from '@shared/models/user/user';
import { Member } from '@shared/models/member/member';
import { SpinnerService } from '@core/services/spinner.service';

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
    user: User;
    member: Member;
    organization: Organization;

    constructor(
        private teamService: TeamService,
        public authService: AuthenticationService,
        public dialogService: DialogService,
        private toastService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) { super(); }

    ngOnInit() {
        this.spinnerService.show(true);
        this.user = this.authService.getUser();
        this.authService.getOrganization().pipe(this.untilThis).subscribe(org => {
            this.organization = org;
            this.authService.getMember().pipe(this.untilThis)
                .subscribe(member => {
                    this.member = member;
                    this.spinnerService.hide();
                });
        });
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
                    this.spinnerService.show(true);
                    this.teamService
                        .createTeam({
                            createdBy: this.user.id,
                            organizationId: this.organization.id,
                            name
                        })
                        .pipe(this.untilThis)
                        .subscribe(team => {
                            this.teamCreated$.next(team);
                            this.spinnerService.hide();
                            this.toastService.success('Team successfully created!', '', 2000);
                        }, error => {
                            this.toastService.error(`${error}`, 'Error', 2000);
                            this.spinnerService.hide();
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
