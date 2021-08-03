import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {Team} from "@shared/models/team/team";
import {TeamService} from "@core/services/team.service";
import {Subject} from "rxjs";
import {takeUntil} from "rxjs/operators";
import {DataService} from "@core/services/share-data.service";

@Component({
  selector: 'app-user-teams',
  templateUrl: './user-teams.component.html',
  styleUrls: ['../teams.component.sass']
})
export class UserTeamsComponent implements OnInit, OnDestroy {
    private unsubscribe$: Subject<Team> = new Subject<Team>();
    @Input() currentUserId: number;
    teams: Team[];

    constructor(public teamService: TeamService, private notifyService: DataService<Team>) { }

    ngOnInit(): void {
        this.teamService
            .getUserTeams(this.currentUserId)
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
                this.teams.push(team);
            });
    }

    public leaveTeam(teamId: number) {
        this.teamService
            .leaveTeam(teamId, this.currentUserId)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(response => {
                this.notifyService.changeMessage(response.body);
                this.teams = this.teams.filter(t => t.id !== teamId);
            }, error => {
                console.log(error);
            });
    }

    ngOnDestroy(): void {
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }
}
