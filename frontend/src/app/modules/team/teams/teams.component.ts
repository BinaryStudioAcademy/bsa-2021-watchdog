import {Component, OnInit} from '@angular/core';
import {Team} from "@shared/models/team/team";
import {TeamService} from "@core/services/team.service";
import {Subject} from "rxjs";
import {takeUntil} from "rxjs/operators";

@Component({
    selector: 'app-teams',
    templateUrl: './teams.component.html',
    styleUrls: ['./teams.component.sass']
})
export class TeamsComponent implements OnInit {
    private unsubscribe$: Subject<Team> = new Subject<Team>();
    userTeams: Team[];
    otherTeams: Team[];
    //fake
    currentUserId: number = 2;

    constructor(private teamService: TeamService) { }

    ngOnInit(): void {
        this.teamService
            .getTeams()
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(teams => {
                this.userTeams = teams.body.filter(t => t.createdBy === this.currentUserId);
                this.otherTeams = teams.body.filter(t => t.createdBy !== this.currentUserId);
            }, error => {
                console.log(error);
            });
    }


}
