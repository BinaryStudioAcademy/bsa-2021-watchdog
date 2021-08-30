import { SpinnerService } from '@core/services/spinner.service';
import { IssuesHubService } from '@core/hubs/issues-hub.service';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { MemberService } from '@core/services/member.service';
import { forkJoin } from 'rxjs';
import { TeamService } from '@core/services/team.service';
import { Assignee } from '@shared/models/issue/assignee';
import { count, toUsers } from '@core/services/issues.utils';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { debounceTime, tap } from 'rxjs/operators';
import { AssigneeOptions } from '@shared/models/issue/assignee-options';
import { IssueService } from '@core/services/issue.service';
import { LazyLoadEvent } from 'primeng/api';
import { Member } from '@shared/models/member/member';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent extends BaseComponent implements OnInit {
    issues: IssueInfo[] = [];
    issuesCount: { [type: string]: number };
    selectedIssues: IssueInfo[] = [];
    isAssign: boolean;
    sharedOptions = {} as AssigneeOptions;
    globalFilterFields = ['errorClass', 'projectName'];
    lastEvent: LazyLoadEvent;
    loading: boolean;
    totalRecords: number;
    member: Member;
    itemsPerPage = 10;
    toAssign: Assignee;
    issueId: number;
    IssueStatus = IssueStatus;
    private saveAssign: Assignee;
    private viewedAssignee = 3;

    constructor(
        private issuesHub: IssuesHubService,
        private issueService: IssueService,
        private toastNotification: ToastNotificationService,
        private authService: AuthenticationService,
        private memberService: MemberService,
        private teamService: TeamService,
        private spinner: SpinnerService
    ) {
        super();
    }

    ngOnInit(): void {
        this.isAssign = false;

        this.setTabPanelFields();

        this.authService.getMember()
            .pipe(
                this.untilThis,
                tap(member => {
                    this.member = member;
                })
            )
            .subscribe(() => {
                forkJoin([this.loadMembers(), this.loadTeams()])
                    .pipe(this.untilThis)
                    .subscribe(async ([members, teams]) => {
                        this.sharedOptions.members = members;
                        this.sharedOptions.teams = teams;
                        await this.loadIssuesLazy(this.lastEvent);
                        this.subscribeToIssuesHub();
                    });
            }, error => {
                this.toastNotification.error(error);
            });
    }

    loadMembers() {
        return this.memberService.getMembersByOrganizationId(this.member.organizationId)
            .pipe(this.untilThis);
    }

    loadTeams() {
        return this.teamService.getTeamOptionsByOrganizationId(this.member.organizationId)
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

    openAssign(issue: IssueInfo) {
        this.toAssign = issue.assignee;
        this.issueId = issue.issueId;
        this.saveAssign = { memberIds: this.toAssign.memberIds.concat(), teamIds: this.toAssign.teamIds.concat() };
        this.isAssign = true;
    }

    closeAssign() {
        if (!this.compareAssigns()) {
            const updateAssignee = {
                assignee: this.toAssign,
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

    async loadIssuesLazy(event: LazyLoadEvent) {
        if (!event) {
            return;
        }
        this.lastEvent = event;
        if (!this.member) {
            return;
        }
        this.spinner.show(true);
        this.issueService.getIssuesInfoLazy(this.member.id, this.lastEvent)
            .pipe(this.untilThis,
                debounceTime(1000))
            .subscribe(
                response => {
                    this.issues = response.collection.concat();
                    this.totalRecords = response.totalRecords;
                    this.spinner.hide();
                },
                error => {
                    this.toastNotification.error(error);
                    this.spinner.hide();
                }
            );
    }

    getNumberAssignee(assignee: Assignee) {
        return count(assignee);
    }

    getNumberExtraAssignee(assignee: Assignee): string {
        return `+${count(assignee) - this.viewedAssignee}`;
    }

    getUsers(assignee: Assignee) {
        return toUsers(assignee.memberIds.slice(0, this.viewedAssignee), this.sharedOptions.members);
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

    private compareAssigns() {
        if (this.saveAssign.memberIds.length !== this.toAssign.memberIds.length) {
            return false;
        }
        if (this.saveAssign.teamIds.length !== this.toAssign.teamIds.length) {
            return false;
        }
        const before = {
            memberIds: this.saveAssign.memberIds.concat().sort(),
            teamIds: this.saveAssign.teamIds.concat().sort()
        };
        const after = {
            memberIds: this.toAssign.memberIds.concat().sort(),
            teamIds: this.toAssign.teamIds.concat().sort()
        };

        const equalsMembers = before.memberIds.every((item, index) => item === after.memberIds[index]);
        const equalsTeams = before.teamIds.every((item, index) => item === after.teamIds[index]);

        return equalsMembers && equalsTeams;
    }

    private subscribeToIssuesHub() {
        this.issuesHub.messages.pipe(this.untilThis)
            .subscribe(async () => {
                await this.loadIssuesLazy(this.lastEvent);
            });
    }

    private setTabPanelFields() {
        this.issuesCount = {
            all: 0,
            active: 0,
            resolved: 0,
            ignored: 0,
        };
    }
}
