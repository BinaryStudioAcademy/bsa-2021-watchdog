import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { TeamService } from '@core/services/team.service';
import { Observable } from 'rxjs';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';

@Component({
    selector: 'app-user-teams',
    templateUrl: './user-teams.component.html',
    styleUrls: ['../teams.component.sass', '../../team.style.sass']
})
export class UserTeamsComponent extends BaseComponent implements OnInit {
    @Input() newTeamCreated: Observable<Team> = new Observable<Team>();
    @Input() joinNewTeam: Observable<Team> = new Observable<Team>();

    @Output() leaveTeamEvent: EventEmitter<Team> = new EventEmitter<Team>();

    @Input() currentOrganizationId: number;
    @Input() currentMemberId: number;

    teams: Team[];
    isLoading: boolean = false;

    constructor(public teamService: TeamService, private toastService: ToastNotificationService) {
        super();
    }

    ngOnInit(): void {
        this.loadMemberTeams();

        this.newTeamCreated
            .pipe(this.untilThis)
            .subscribe(team => {
                this.loadMemberTeams();
                this.toastService.success(`Team #${team.name} created!`, '', 1500);
            });

        this.joinNewTeam
            .pipe(this.untilThis)
            .subscribe(team => {
                this.loadMemberTeams();
                this.toastService.success(`You have successfully joined to #${team.name} team!`, '', 1500);
            });
    }

    public leaveTeam(teamId: number) {
        this.teamService
            .leaveTeam(teamId, this.currentMemberId)
            .pipe(this.untilThis)
            .subscribe(team => {
                this.leaveTeamEvent.emit(team);
                this.loadMemberTeams();
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
    }

    private loadMemberTeams() {
        this.isLoading = true;

        this.teamService
            .getMemberTeams(this.currentOrganizationId, this.currentMemberId)
            .pipe(this.untilThis)
            .subscribe(teams => {
                this.isLoading = false;
                this.teams = teams;
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
                this.isLoading = false;
            });
    }
}
