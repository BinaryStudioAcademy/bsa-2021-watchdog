import { ToastNotificationService } from "./../../../../core/services/toast-notification.service";
import { TeamService } from "@core/services/team.service";
import { Component, Input, OnInit } from "@angular/core";
import { Team } from '@shared/models/team/team';

@Component({
    selector: 'app-team-members',
    templateUrl: './team-members.component.html',
    styleUrls: ['./team-members.component.sass']
})
export class TeamMembersComponent implements OnInit {
    @Input() team: Team;
    isLoading: boolean = false;
    constructor(private teamService: TeamService, private toastService: ToastNotificationService) { }

    ngOnInit() {
    }

    removeFromTeam(memberId: number) {
        this.isLoading = true;
        this.teamService.leaveTeam(this.team.id, memberId)
            .subscribe(() => {
                this.team.members = this.team.members.filter(member => member.id != memberId);
                this.toastService.success("Successfully removed team member");
                this.isLoading = false;
            }, error => {
                this.toastService.error(error);
                this.isLoading = false;
            });
    }

}
