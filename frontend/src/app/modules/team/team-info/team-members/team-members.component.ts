import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@shared/models/user/user';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TeamService } from '@core/services/team.service';
import { Component, Input } from '@angular/core';
import { Team } from '@shared/models/teams/team';
import { Member } from '@shared/models/member/member';
import { SpinnerService } from '@core/services/spinner.service';
import { hasAccess } from '@core/utils/access.utils';

@Component({
    selector: 'app-team-members',
    templateUrl: './team-members.component.html',
    styleUrls: ['../../team.style.sass']
})
export class TeamMembersComponent extends BaseComponent {
    @Input() team: Team;
    @Input() member: Member;

    constructor(
        private teamService: TeamService,
        private toastService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) {
        super();
    }

    hasAccess = () => hasAccess(this.member);

    members: User[];
    filterExpression: string;

    removeMember(memberId: number) {
        this.spinnerService.show(true);
        this.teamService.leaveTeam(this.team.id, memberId)
            .subscribe(() => {
                this.team.members = this.team.members.filter(member => member.id !== memberId);
                this.toastService.success('Member was removed!');
                this.spinnerService.hide();
            }, error => {
                this.toastService.error(error);
                this.spinnerService.hide();
            });
    }

    addMember(member: Member) {
        this.spinnerService.show(true);
        this.teamService.joinTeam(this.team.id, member.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.team.members = this.team.members.concat(member);
                this.spinnerService.hide();
                this.toastService.success('Member was added!');
            }, error => {
                this.spinnerService.hide();
                this.toastService.error(error);
            });
    }
}
