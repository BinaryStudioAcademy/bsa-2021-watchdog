import { Component, EventEmitter, Input, Output } from '@angular/core';
import { hasAccess } from '@core/utils/access.utils';
import { Member } from '@shared/models/member/member';
import { Team } from '@shared/models/teams/team';

@Component({
    selector: 'app-other-teams',
    templateUrl: '../teams-panel.template.html',
    styleUrls: ['../teams.component.sass', '../../team.style.sass']
})
export class OtherTeamsComponent {
    @Output() joinedTeam: EventEmitter<number> = new EventEmitter<number>();
    @Input() teams: Team[];
    @Input() member: Member;

    hasAccess = () => hasAccess(this.member);

    title: string = 'Other Teams';
    placeholder: string = this.hasAccess() ? 'There is no teams, you can join' : 'You are in all the teams';
    buttonLabel: string = 'Join team';
    buttonClass: string = 'p-button-outlined';
    icon: string = 'pi pi-plus-circle';

    sendTeam(teamId: number) {
        this.joinedTeam.next(teamId);
    }
}
