import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Team } from '@shared/models/teams/team';

@Component({
    selector: 'app-user-teams',
    templateUrl: '../teams-panel.template.html',
    styleUrls: ['../teams.component.sass', '../../team.style.sass']
})
export class UserTeamsComponent {
    @Output() leavedTeam: EventEmitter<number> = new EventEmitter<number>();
    @Input() teams: Team[];

    title: string = 'User Teams';
    placeholder: string = 'There is no teams, you can leave.';
    buttonLabel: string = 'Leave team';
    buttonClass: string = 'p-button-outlined p-button-danger';

    sendTeam(teamId: number) {
        this.leavedTeam.next(teamId);
    }
}
