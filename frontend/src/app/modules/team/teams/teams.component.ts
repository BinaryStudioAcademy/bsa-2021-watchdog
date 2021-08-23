import { switchMap } from 'rxjs/operators';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { TeamService } from '@core/services/team.service';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateTeamComponent } from '@modules/team/create-team/create-team.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { User } from '@shared/models/user/user';
import { Member } from '@shared/models/member/member';
import { SpinnerService } from '@core/services/spinner.service';
import { forkJoin } from 'rxjs';

@Component({
    selector: 'app-teams',
    templateUrl: './teams.component.html',
    styleUrls: ['./teams.component.sass', '../team.style.sass'],
    providers: [DialogService]
})
export class TeamsComponent extends BaseComponent implements OnInit, OnDestroy {
    memberInTeams: Team[];
    notMemberInTeams: Team[];

    createTeamDialog: DynamicDialogRef;
    user: User;
    member: Member;

    constructor(
        private teamService: TeamService,
        private authService: AuthenticationService,
        private dialogService: DialogService,
        private toastService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) { super(); }

    ngOnInit() {
        this.spinnerService.show(true);
        this.authService.getMember()
            .pipe(this.untilThis, switchMap(member => {
                this.member = member;
                return forkJoin([
                    this.teamService.getMemberTeams(member.organizationId, member.id),
                    this.teamService.getNotMemberTeams(member.organizationId, member.id)
                ]);
            })).subscribe(([memberInTeams, notMemberInTeams]) => {
                this.memberInTeams = memberInTeams;
                this.notMemberInTeams = notMemberInTeams;
                this.spinnerService.hide();
            }, error => {
                this.toastService.error(error);
                this.spinnerService.hide();
            });
    }

    openDialog() {
        this.createTeamDialog = this.dialogService.open(CreateTeamComponent, {
            header: 'Creating team',
            width: '35%',
            showHeader: true,
            baseZIndex: 10000,
        });

        this.createTeamDialog.onClose
            .pipe(this.untilThis)
            .subscribe((name: string) => {
                if (name) {
                    this.spinnerService.show(true);
                    this.teamService
                        .createTeam({
                            createdBy: this.member.user.id,
                            organizationId: this.member.organizationId,
                            name
                        })
                        .pipe(this.untilThis)
                        .subscribe(team => {
                            this.memberInTeams = [...this.memberInTeams, team];
                            this.spinnerService.hide();
                            this.toastService.success('Team successfully created!');
                        }, error => {
                            this.toastService.error(error);
                            this.spinnerService.hide();
                        });
                }
            });
    }

    leaveTeam(teamId: number) {
        this.spinnerService.show(true);
        this.teamService.leaveTeam(teamId, this.member.id)
            .pipe(this.untilThis)
            .subscribe(leavedTeam => {
                this.memberInTeams = this.memberInTeams.filter(team => team.id !== leavedTeam.id);
                this.notMemberInTeams = [...this.notMemberInTeams, leavedTeam];
                this.spinnerService.hide();
            }, error => {
                this.spinnerService.hide();
                this.toastService.error(error);
            });
    }

    joinTeam(teamId: number) {
        this.spinnerService.show(true);
        this.teamService.joinTeam(teamId, this.member.id)
            .pipe(this.untilThis)
            .subscribe(joinedTeam => {
                this.memberInTeams = [...this.memberInTeams, joinedTeam];
                this.notMemberInTeams = this.notMemberInTeams.filter(team => team.id !== joinedTeam.id);
                this.spinnerService.hide();
            }, error => {
                this.spinnerService.hide();
                this.toastService.error(error);
            });
    }
}
