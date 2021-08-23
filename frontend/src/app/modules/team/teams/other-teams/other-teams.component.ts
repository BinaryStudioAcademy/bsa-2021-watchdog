import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Team } from '@shared/models/teams/team';

@Component({
    selector: 'app-other-teams',
    templateUrl: '../teams-panel.template.html',
    styleUrls: ['../teams.component.sass', '../../team.style.sass']
})
export class OtherTeamsComponent {
    @Output() joinedTeam: EventEmitter<number> = new EventEmitter<number>();
    @Input() teams: Team[];

    title: string = 'Other Teams';
    placeholder: string = 'There is no teams, you can join.';
    buttonLabel: string = 'Join team';
    buttonClass: string = 'p-button-outlined';

    sendTeam(teamId: number) {
        this.joinedTeam.next(teamId);
    }
}
