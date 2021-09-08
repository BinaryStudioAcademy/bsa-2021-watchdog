import { Member } from '@shared/models/member/member';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { hasAccess } from '@core/utils/access.utils';

@Component({
    selector: 'app-user-teams',
    templateUrl: '../teams-panel.template.html',
    styleUrls: ['../teams.component.sass', '../../team.style.sass']
})
export class UserTeamsComponent {
    @Output() leavedTeam: EventEmitter<number> = new EventEmitter<number>();
    @Input() teams: Team[];
    @Input() member: Member;

    hasAccess = () => hasAccess(this.member);

    title: string = 'User Teams';
    placeholder: string = this.hasAccess() ? 'There is no teams, you can leave' : 'You are not a member of any team';
    buttonLabel: string = 'Leave team';
    buttonClass: string = 'p-button-outlined p-button-danger';
    icon: string = 'pi pi-minus-circle';

    sendTeam(teamId: number) {
        this.leavedTeam.next(teamId);
    }
}
