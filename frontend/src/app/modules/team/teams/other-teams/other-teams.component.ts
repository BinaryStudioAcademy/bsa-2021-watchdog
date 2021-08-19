import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { TeamService } from '@core/services/team.service';
import { Observable } from 'rxjs';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-other-teams',
    templateUrl: './other-teams.component.html',
    styleUrls: ['../teams.component.sass', '../../team.style.sass']
})
export class OtherTeamsComponent extends BaseComponent implements OnInit {
    @Input() leavedTeam: Observable<Team> = new Observable<Team>();
    @Output() joinTeamEvent: EventEmitter<Team> = new EventEmitter<Team>();

    @Input() currentOrganizationId: number;
    @Input() currentMemberId: number;

    teams: Team[];

    constructor(
        public teamService: TeamService,
        private toastService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) {
        super();
    }

    ngOnInit(): void {
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
            .joinTeam(teamId, this.currentMemberId)
            .pipe(this.untilThis)
            .subscribe(team => {
                this.joinTeamEvent.emit(team);
                this.loadTeams();
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
    }

    private loadTeams() {
        this.spinnerService.show(true);

        this.teamService
            .getNotMemberTeams(this.currentOrganizationId, this.currentMemberId)
            .pipe(this.untilThis)
            .subscribe(teams => {
                this.spinnerService.hide();
                this.teams = teams;
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
    }
}
