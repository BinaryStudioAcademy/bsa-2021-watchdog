import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { TeamService } from '@core/services/team.service';
import { Assignment } from '@shared/models/issue/assignment';
import { RecipientTeam } from '@shared/models/projects/recipient-team';

@Component({
    selector: 'app-assignment-of-teams',
    templateUrl: './assignment-of-teams.component.html',
    styleUrls: ['./assignment-of-teams.component.sass']
})
export class AssignmentOfTeamsComponent extends BaseComponent {
    avatar: string;
    teamLabel: string;

    @Input() assignment = {} as Assignment;
    @Input() teams: RecipientTeam[];
    @Output() closeModal = new EventEmitter<void>();

    constructor(private teamService: TeamService) {
        super();
    }

    getLabel = this.teamService.getLabel;
}
