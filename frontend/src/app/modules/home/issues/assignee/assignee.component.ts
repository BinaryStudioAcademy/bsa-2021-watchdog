import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { TeamService } from '@core/services/team.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Assignee } from '@shared/models/issue/assignee';
import { Member } from '@shared/models/member/member';
import { TeamOption } from '@shared/models/teams/team-option';

@Component({
    selector: 'app-assignee',
    templateUrl: './assignee.component.html',
    styleUrls: ['./assignee.component.sass']
})
export class AssigneeComponent extends BaseComponent {
    avatar: string;
    teamLabel: string;
    @Input() data = {} as Assignee;
    @Input() members: Member[];
    @Input() teams: TeamOption[];
    @Output() closeModal = new EventEmitter<void>();
    constructor(
        private toastNotification: ToastNotificationService,
        private teamService: TeamService
    ) {
        super();
    }
    getLabel = this.teamService.getLabel;
}
