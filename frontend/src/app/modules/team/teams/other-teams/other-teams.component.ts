import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Team } from '@shared/models/team/team';
import { TeamService } from '@core/services/team.service';
import { Observable } from 'rxjs';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';

@Component({
    selector: 'app-other-teams',
    templateUrl: './other-teams.component.html',
    styleUrls: ['../teams.component.sass']
})
export class OtherTeamsComponent extends BaseComponent implements OnInit {
    @Input() leavedTeam: Observable<Team> = new Observable<Team>();
    @Output() joinTeamEvent: EventEmitter<Team> = new EventEmitter<Team>();

    @Input() currentOrganizationId: number;
    @Input() currentUserId: number;

    teams: Team[];
    isLoading: boolean = false;

    constructor(public teamService: TeamService, private toastService: ToastNotificationService) {
        super();
    }

    ngOnInit(): void {
        //to test error catching
        throw new Error();

        this.loadTeams();

        this.leavedTeam
            .pipe(this.untilThis)
            .subscribe(team => {
                this.loadTeams();
                this.toastService.success(`You have successfully left from #${team.name}.`, '', 1500);
            });
    }

    joinTeam(teamId: number) {
        this.teamService
            .joinTeam({ teamId, memberId: this.currentUserId })
            .pipe(this.untilThis)
            .subscribe(response => {
                this.joinTeamEvent.emit(response.body);
                this.loadTeams();
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
    }

    private loadTeams() {
        this.isLoading = true;

        this.teamService
            .getNotMemberTeams(this.currentOrganizationId, this.currentUserId)
            .pipe(this.untilThis)
            .subscribe(teams => {
                this.isLoading = false;
                this.teams = teams.body;
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
    }
}
