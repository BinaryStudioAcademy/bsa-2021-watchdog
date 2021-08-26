import { IssueMessage } from '@shared/models/issue/issue-message';
import { IssuesHubService } from '@core/hubs/issues-hub.service';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Organization } from '@shared/models/organization/organization';
import { AuthenticationService } from '@core/services/authentication.service';
import { MemberService } from '@core/services/member.service';
import { forkJoin, Observable } from 'rxjs';
import { TeamService } from '@core/services/team.service';
import { Assignee } from '@shared/models/issue/assignee';
import { count, toImages } from '@core/services/issues.utils';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { debounceTime, tap } from 'rxjs/operators';
import { AssigneeOptions } from '@shared/models/issue/assignee-options';
import { IssueService } from '@core/services/issue.service';
import { LazyLoadEvent } from 'primeng/api';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent extends BaseComponent implements OnInit {
    issues: IssueInfo[] = [];

    issuesCount: { [type: string]: number };

    selectedIssues: IssueInfo[] = [];

    timeOptions: string[];

    selectedTime: string;
    isAssign: boolean;
    sharedOptions = {} as AssigneeOptions;
    organization: Organization;
    globalFilterFields = ['errorClass'];
    lastEvent: LazyLoadEvent;
    loading: boolean = false;
    totalRecords: number;
    organizationRequest: Observable<Organization>;

    constructor(
        private issuesHub: IssuesHubService,
        private issueService: IssueService,
        private toastNotification: ToastNotificationService,
        private authService: AuthenticationService,
        private memberService: MemberService,
        private teamService: TeamService
    ) { super(); }

    itemsPerPage = 10;

    ngOnInit(): void {
        this.isAssign = false;

        this.setTabPanelFields();
        const request = this.authService.getOrganization()
            .pipe(
                this.untilThis,
                tap(organization => {
                    this.organization = organization;
                })
            );

        this.organizationRequest = request;

        request
            .subscribe(() => {
                this.loadIssuesLazy(this.lastEvent);
                forkJoin([this.loadMember(), this.loadTeams()])
                    .pipe(this.untilThis)
                    .subscribe(([members, teams]) => {
                        this.sharedOptions.members = members;
                        this.sharedOptions.teams = teams;
                        this.subscribeToIssuesHub();
                    });
            }, error => {
                this.toastNotification.error(error);
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
    issueId: number;
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
                    this.toastNotification.success('Assignee updated');
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

    async loadIssuesLazy(event: LazyLoadEvent) {
        if (!event) {
            return;
        }
        this.lastEvent = event;
        if (!this.organization) {
            await this.organizationRequest.toPromise();
        }
        this.issueService.getIssuesInfoLazy(this.lastEvent)
            .pipe(this.untilThis,
                debounceTime(1000))
            .subscribe(
                response => {
                    this.issues = response.collection;
                    this.totalRecords = response.totalRecord;
                },
                error => {
                    this.toastNotification.error(error);
                }
            );
    }

    private subscribeToIssuesHub() {
        this.issuesHub.messages.pipe(this.untilThis)
            .subscribe(issue => { this.addIssue(issue); });
    }

    private addIssue(issue: IssueMessage) {
        const existingIssue = this.issues.find(i => i.issueId === issue.issueId);
        this.issues = existingIssue ? this.addExistingIssue(issue, existingIssue) : this.addNewIssue(issue);
    }

    private addNewIssue(issue: IssueMessage) {
        const issueInfo: IssueInfo = {
            issueId: issue.issueId,
            errorClass: issue.issueDetails.className,
            errorMessage: issue.issueDetails.errorMessage,
            eventsCount: 1,
            affected: 1,
            newest: { id: issue.id, occurredOn: issue.occurredOn },
            assignee: { teamIds: [], memberIds: [] },
        };
        this.issuesCount.all += 1;
        return [issueInfo, ...this.issues];
    }

    private addExistingIssue(issue: IssueMessage, existingIssue: IssueInfo) {
        const changedIssue = {
            ...existingIssue,
            eventsCount: existingIssue.eventsCount + 1,
            newest: { id: issue.id, occurredOn: issue.occurredOn },
        };
        return [
            changedIssue,
            ...this.issues.filter(i =>
                i.issueId !== changedIssue.issueId)
        ];
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

    private setTabPanelFields() {
        this.issuesCount = {
            all: 0,
            secondtype: 0,
            thirdtype: 0
        };
    }
}
