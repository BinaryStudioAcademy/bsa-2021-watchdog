import { BaseComponent } from "@core/components/base/base.component";
import { User } from '@shared/models/user/user';
import { ToastNotificationService } from "@core/services/toast-notification.service";
import { TeamService } from "@core/services/team.service";
import { Component, Input, OnInit } from "@angular/core";
import { Team } from '@shared/models/team/team';
import { Member } from "@shared/models/member/member";

@Component({
    selector: 'app-team-members',
    templateUrl: './team-members.component.html',
    styleUrls: ['../../team.style.sass']
})
export class TeamMembersComponent extends BaseComponent implements OnInit {
    @Input() team: Team;
    isLoading: boolean = false;
    constructor(private teamService: TeamService, private toastService: ToastNotificationService) {
        super();
    }

    members: User[];
    filterExpression: string;

    ngOnInit() {

    }

    removeMember(memberId: number) {
        this.isLoading = true;
        this.teamService.leaveTeam(this.team.id, memberId)
            .subscribe(() => {
                this.team.members = this.team.members.filter(member => member.id != memberId);
                this.toastService.success("Member was removed!");
                this.isLoading = false;
            }, error => {
                this.toastService.error(error);
                this.isLoading = false;
            });
    }

    addMember(member: Member) {
        this.isLoading = true;
        this.teamService.joinTeam(this.team.id, member.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.team.members = this.team.members.concat(member);
                this.isLoading = false;
                this.toastService.success("Member was added!");
            }, error => {
                this.isLoading = false;
                this.toastService.error(error);
            });
    }
}
