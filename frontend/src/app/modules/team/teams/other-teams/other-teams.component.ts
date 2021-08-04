import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Team } from '@shared/models/team/team';
import { TeamService } from '@core/services/team.service';
import { takeUntil } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import {ToastNotificationService} from "@core/services/toast-notification.service";

@Component({
    selector: 'app-other-teams',
    templateUrl: './other-teams.component.html',
    styleUrls: ['../teams.component.sass']
})
export class OtherTeamsComponent implements OnInit, OnDestroy {
    private unsubscribe$: Subject<Team> = new Subject<Team>();

    @Input() newTeam: Observable<Team> = new Observable<Team>();
    @Output() joinTeamEvent: EventEmitter<Team> = new EventEmitter<Team>();

    @Input() currentUserId: number;

    teams: Team[];
    isLoading: boolean = false;

    constructor(public teamService: TeamService, private toastService: ToastNotificationService) { }

    ngOnInit(): void {
        this.isLoading = true;

        this.teamService
            .getNotUserTeams(this.currentUserId)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(teams => {
                this.isLoading = false;
                this.teams = teams.body;
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });

        this.newTeam
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(team => {
                this.teams.push(team);
                this.toastService.success(`You have successfully left from #${team.name}.`, '', 1500);
            });
    }

    joinTeam(teamId: number) {
        this.teamService
            .joinTeam({ teamId, memberId: this.currentUserId })
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(response => {
                this.joinTeamEvent.emit(response.body);
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
