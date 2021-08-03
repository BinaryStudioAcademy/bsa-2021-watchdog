import { Component, OnInit } from '@angular/core';
import { Team } from '@shared/models/team/team';
import { TeamService } from '@core/services/team.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import {DialogService, DynamicDialogRef} from 'primeng/dynamicdialog';
import {CreateTeamComponent} from "@modules/team/create-team/create-team.component";

@Component({
    selector: 'app-teams',
    templateUrl: './teams.component.html',
    styleUrls: ['./teams.component.sass'],
    providers: [DialogService]
})
export class TeamsComponent implements OnInit {
    private unsubscribe$: Subject<Team> = new Subject<Team>();
    public teamCreated$: Subject<Team> = new Subject<Team>();

    userTeams: Team[];
    otherTeams: Team[];
    teamCreating: boolean = false;
    createTeamDialog: DynamicDialogRef;

    //fake
    currentUserId: number = 10;
    currentOrganizationId: number = 3;

    constructor(private teamService: TeamService, public dialogService: DialogService) { }

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

    openDialog() {
        this.createTeamDialog = this.dialogService.open(CreateTeamComponent, {
            header: 'Creating team',
            width: '35%',
            styleClass: '.create-team-dialog',
            showHeader: true,
            baseZIndex: 10000
        });

        this.createTeamDialog.onClose
            .subscribe((name: string) => {
                this.teamService
                    .createTeam({
                        createdBy: this.currentUserId,
                        organizationId: this.currentOrganizationId,
                        name: name
                    }).pipe(takeUntil(this.unsubscribe$))
                    .subscribe(team => {
                        this.teamCreated$.next(team.body);
                    }, error => {
                        console.log(error);
                    })
            })
    }
}
