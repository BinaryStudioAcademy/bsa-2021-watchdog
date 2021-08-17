import { Component, OnInit } from '@angular/core';
import { Issue } from '@shared/models/issue/issue';
import { IssueService } from '@core/services/issue.service';
import { IssueMessage } from '@shared/models/issues/issue-message';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Member } from '@shared/models/member/member';
import { TeamOption } from '@shared/models/teams/team-option';
import { Organization } from '@shared/models/organization/organization';
import { AuthenticationService } from '@core/services/authentication.service';
import { MemberService } from '@core/services/member.service';
import { forkJoin, of } from 'rxjs';
import { TeamService } from '@core/services/team.service';
import { Assignee } from '@shared/models/assignee/assignee';
import { count, toImages } from '@core/services/issues.utils';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent extends BaseComponent implements OnInit {
    issues: IssueMessage[];

    countNew: { [type: string]: number };

    selectedIssues: Issue[] = [];

    timeOptions: string[];

    selectedTime: string;
    isAssign: boolean;
    sharedOptions = { members: [] as Member[], teams: [] as TeamOption[] };
    organization: Organization;

    constructor(private issueService: IssueService, private toastNotification: ToastNotificationService,
        private authService: AuthenticationService, private memberService: MemberService, private teamService: TeamService) {
        super();
    }

    ngOnInit(): void {
        this.isAssign = false;
        this.setAllFieldsTemp();
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;
                forkJoin([this.loadMember(), this.loadTeams(), this.loadIssues()])
                    .pipe(this.untilThis)
                    .subscribe(([members, teams, issues]) => {
                        this.sharedOptions.members = members;
                        this.sharedOptions.teams = teams;
                        this.issues = issues;
                    });
            }, errorResponse => {
                this.toastNotification.error(errorResponse);
            });
    }
    loadMember() {
        return this.memberService.getMembersByOrganizationId(this.organization.id)
            .pipe(this.untilThis);
    }

    loadTeams() {
        return this.teamService.getTeamOptionsByOrganizationId(this.organization.id)
            .pipe(this.untilThis);
    }

    selectAll(event: { checked: boolean, originalEvent: Event }) {
        this.disableParentEvent(event);
        if (event.checked) {
            this.selectedIssues = Object.assign([], this.issues);
        } else {
            this.selectedIssues = [];
        }
    }

    disableParentEvent(event: { originalEvent: Event }) { // to disable sorting
        event.originalEvent.stopPropagation();
    }

    toAssing: Assignee;
    private saveAssing: Assignee;
    openAssign(issue: IssueMessage) {
        this.toAssing = issue.assignee;
        this.saveAssing = { memberIds: this.toAssing.memberIds.concat(), teamIds: this.toAssing.teamIds.concat() };
        this.isAssign = true;
    }

    closeAssing() {
        if (!this.compareAssigns()) {
            // запрос в базу
        }
        this.isAssign = false;
    }

    private compareAssigns() {
        if (this.saveAssing.memberIds.length !== this.toAssing.memberIds.length) {
            return false;
        }
        if (this.saveAssing.teamIds.length !== this.toAssing.teamIds.length) {
            return false;
        }
        const before = {
            memberIds: this.saveAssing.memberIds.concat().sort(),
            teamIds: this.saveAssing.teamIds.concat().sort()
        };
        const after = {
            memberIds: this.toAssing.memberIds.concat().sort(),
            teamIds: this.toAssing.teamIds.concat().sort()
        };

        const equalsMembers = before.memberIds.every((item, index) => item === after.memberIds[index]);
        const equalsTeams = before.teamIds.every((item, index) => item === after.teamIds[index]);

        return equalsMembers && equalsTeams;
    }

    private loadIssues() {
        return of([{
            occurredOn: new Date(),
            issueDetails: {
                url: 'test',
                errorMessage: 'test',
                className: 'test',
                environmentMessage: {
                    browser: 'string',
                    browserName: 'string',
                    browserVersion: 'string',
                    platform: 'string'
                }
            },
            assignee: { teamIds: [6], memberIds: [31] }
        }]);
        return this.issueService.getIssues()
            .pipe(this.untilThis);
    }

    private setAllFieldsTemp() {
        this.countNew = {
            all: 3,
            secondtype: 1,
            thirdtype: 0
        };
    }

    private viewedAssignee = 3;
    getNumberAssignee(assignee: Assignee) {
        return count(assignee);
    }

    getNumberExtraAssignee(assignee: Assignee): string {
        return `+${count(assignee) - this.viewedAssignee}`;
    }

    getMembersImages(assignee: Assignee) {
        return toImages(assignee.memberIds.slice(0, this.viewedAssignee), this.sharedOptions.members);
    }

    getTeamsLabels(assignee: Assignee) {
        const diff = this.viewedAssignee - assignee.memberIds.length;
        if (diff <= 0) {
            return [];
        }
        return assignee.teamIds.slice(0, diff)
            .map(id => this.teamService
                .getLabel(this.sharedOptions.teams.find(t => t.id === id).name));
    }
}
