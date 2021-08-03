import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {Team} from "@shared/models/team/team";
import {TeamService} from "@core/services/team.service";
import {takeUntil} from "rxjs/operators";
import {Subject, Subscription} from "rxjs";
import {DataService} from "@core/services/share-data.service";

@Component({
    selector: 'app-other-teams',
    templateUrl: './other-teams.component.html',
    styleUrls: ['../teams.component.sass']
})
export class OtherTeamsComponent implements OnInit, OnDestroy {
    private unsubscribe$: Subject<Team> = new Subject<Team>();
    @Input()currentUserId: number;
    teams: Team[];
    labels: string[];

    constructor(public teamService: TeamService, private notifyService: DataService<Team>) { }

    ngOnInit(): void {
        this.teamService
            .getNotUserTeams(this.currentUserId)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(teams => {
                this.teams = teams.body;
            }, error => {
                console.log(error);
            });

        this.notifyService
            .currentMessage
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(team => {
                console.log(team)
                this.teams.push(team);
            });
    }

    joinTeam(teamId: number) {
        this.teamService
            .joinTeam({teamId: teamId, memberId: this.currentUserId})
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(response => {
                this.notifyService.changeMessage(response.body);
                this.teams = this.teams.filter(t => t.id != teamId);
            }, error => {
                console.log(error);
            });
    }

    ngOnDestroy(): void {
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }
}
