import { Component, OnInit } from '@angular/core';
import { IssueService } from '@core/services/issue.service';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Member } from '@shared/models/member/member';
import { TeamOption } from '@shared/models/teams/team-option';
import { Organization } from '@shared/models/organization/organization';
import { AuthenticationService } from '@core/services/authentication.service';
import { MemberService } from '@core/services/member.service';
import { forkJoin } from 'rxjs';
import { TeamService } from '@core/services/team.service';
import { Assignee } from '@shared/models/issue/assignee';
import { count, toImages } from '@core/services/issues.utils';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { map } from 'rxjs/operators';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent extends BaseComponent implements OnInit {
    issues: IssueInfo[] = [];

    countNew: { [type: string]: number };

    selectedIssues: IssueInfo[] = [];

    timeOptions: string[];

    selectedTime: string;
    isAssign: boolean;
    sharedOptions = { members: [] as Member[], teams: [] as TeamOption[] };
    organization: Organization;

    constructor(
        private issueService: IssueService,
        private toastNotification: ToastNotificationService,
        private authService: AuthenticationService,
        private memberService: MemberService,
        private teamService: TeamService
    ) { super(); }

    itemsPerPage = 10;

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
    issueId: string;
    private saveAssing: Assignee;
    openAssign(issue: IssueInfo) {
        this.toAssing = issue.assignee;
        this.issueId = issue.issueId;
        this.saveAssing = { memberIds: this.toAssing.memberIds.concat(), teamIds: this.toAssing.teamIds.concat() };
        this.isAssign = true;
    }

    closeAssing() {
        if (!this.compareAssigns()) {
            const updateAssignee = {
                assignee: this.toAssing,
                issueId: this.issueId,
            };
            this.issueService.updateAssignee(updateAssignee)
                .pipe(this.untilThis)
                .subscribe(() => {
                    this.toastNotification.success('Asignee apdated');
                }, errorResponse => {
                    this.toastNotification.error(errorResponse);
                });
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
        return this.issueService.getIssuesInfo()
            .pipe(this.untilThis,
                map(issues => issues.map(issue => {
                    if (issue.assignee) {
                        return issue;
                    }
                    return { ...issue, assignee: { teamIds: [], memberIds: [] } as Assignee };
                })));
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
