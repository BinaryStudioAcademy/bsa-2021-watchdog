import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Team } from '@shared/models/team/team';
import { TeamService } from '@core/services/team.service';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import {ToastNotificationService} from "@core/services/toast-notification.service";

@Component({
    selector: 'app-user-teams',
    templateUrl: './user-teams.component.html',
    styleUrls: ['../teams.component.sass']
})
export class UserTeamsComponent implements OnInit, OnDestroy {
    private unsubscribe$: Subject<Team> = new Subject<Team>();

    @Input() newTeamCreated: Observable<Team> = new Observable<Team>();
    @Input() joinNewTeam: Observable<Team> = new Observable<Team>();

    @Output() leaveTeamEvent: EventEmitter<Team> = new EventEmitter<Team>();

    @Input() currentUserId: number;
    teams: Team[];
    isLoading: boolean = false;

    constructor(public teamService: TeamService, private toastService: ToastNotificationService) { }

    ngOnInit(): void {
        this.isLoading = true;

        this.teamService
            .getUserTeams(this.currentUserId)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(teams => {
                this.isLoading = false;
                this.teams = teams.body;
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });

        this.joinNewTeam
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(team => {
                this.teams.push(team);
                this.toastService.success(`You have successfully joined to #${team.name} team!`, '', 1500);
            });

        this.newTeamCreated
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(team => {
                this.teams.push(team);
            });
    }

    public leaveTeam(teamId: number) {
        this.teamService
            .leaveTeam(teamId, this.currentUserId)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(response => {
                this.leaveTeamEvent.emit(response.body);
                this.teams = this.teams.filter(t => t.id !== teamId);
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
    }

    ngOnDestroy(): void {
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }
}
