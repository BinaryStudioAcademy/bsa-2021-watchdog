import { Component, OnDestroy } from '@angular/core';
import { Team } from '@shared/models/team/team';
import { TeamService } from '@core/services/team.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateTeamComponent } from '@modules/team/create-team/create-team.component';
import {ToastNotificationService} from "@core/services/toast-notification.service";

@Component({
    selector: 'app-teams',
    templateUrl: './teams.component.html',
    styleUrls: ['./teams.component.sass'],
    providers: [DialogService]
})
export class TeamsComponent implements OnDestroy {
    private unsubscribe$: Subject<Team> = new Subject<Team>();

    public teamCreated$: Subject<Team> = new Subject<Team>();
    public pushToOtherTeams$: Subject<Team> = new Subject<Team>();
    public pushToUserTeams$: Subject<Team> = new Subject<Team>();

    teamCreating: boolean = false;
    createTeamDialog: DynamicDialogRef;

    //fake
    currentUserId: number = 10;
    currentOrganizationId: number = 3;

    constructor(private teamService: TeamService, public dialogService: DialogService, private toastService: ToastNotificationService) { }

    openDialog() {
        this.createTeamDialog = this.dialogService.open(CreateTeamComponent, {
            header: 'Creating team',
            width: '35%',
            showHeader: true,
            baseZIndex: 10000
        });

        this.createTeamDialog.onClose
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe((name: string) => {
                if (name !== undefined) {
                    this.teamService
                        .createTeam({
                            createdBy: this.currentUserId,
                            organizationId: this.currentOrganizationId,
                            name
                        })
                        .pipe(takeUntil(this.unsubscribe$))
                        .subscribe(response => {
                            this.teamCreated$.next(response.body);
                            this.toastService.success('Team successfully created!', '', 2000);
                        }, error => {
                            this.toastService.error(`${error}`, 'Error', 2000)
                        });
                }
            });
    }

    pushToOtherTeams(team: Team) {
        this.pushToOtherTeams$.next(team);
    }

    pushToUserTeams(team: Team) {
        this.pushToUserTeams$.next(team);
    }

    ngOnDestroy(): void {
        this.teamCreated$.next();
        this.teamCreated$.complete();
        this.pushToOtherTeams$.next();
        this.pushToOtherTeams$.complete();
        this.pushToUserTeams$.next();
        this.pushToUserTeams$.complete();
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }
}
