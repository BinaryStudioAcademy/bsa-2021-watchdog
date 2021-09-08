import { TrelloService } from '@core/services/trello-service';
import { Organization } from '@shared/models/organization/organization';
import { SpinnerService } from '@core/services/spinner.service';
import { IssuesHubService } from '@core/hubs/issues-hub.service';
import { Component, Input, OnInit } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { MemberService } from '@core/services/member.service';
import { forkJoin } from 'rxjs';
import { TeamService } from '@core/services/team.service';
import { Assignee } from '@shared/models/issue/assignee';
import { count, toTeams, toUsers } from '@core/services/issues.utils';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { debounceTime, tap, switchMap } from 'rxjs/operators';
import { AssigneeOptions } from '@shared/models/issue/assignee-options';
import { IssueService } from '@core/services/issue.service';
import { LazyLoadEvent } from 'primeng/api';
import { Member } from '@shared/models/member/member';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { TableExportService } from '@core/services/table-export.service';
import { IssueInfoExport } from '@shared/models/export/IssueInfoExport';
import { IssueTableItem } from '@shared/models/issue/issue-table-item';
import { Project } from '@shared/models/projects/project';
import { CountOfIssuesByStatus } from '@shared/models/issue/count-of-issues-by-status';
import { IssueSelect } from '@shared/models/issue/enums/issue-select';
import { IssueSelectDropdown } from '@shared/modules/issues/data/models/issue-select.dropdown';
import { IssueDropdownDataService } from '@shared/modules/issues/data/issue-dropdown-data.service';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass'],
    providers: [IssueDropdownDataService]
})
export class IssuesComponent extends BaseComponent implements OnInit {
    @Input() project: Project;
    issues: IssueTableItem[] = [];
    issuesCount: { [type: string]: number } = {};
    selectedIssues: IssueTableItem[] = [];
    isAssign: boolean;
    sharedOptions = {} as AssigneeOptions;
    globalFilterFields = ['errorClass', 'projectName', 'errorMessage'];
    lastEvent: LazyLoadEvent;
    loading: boolean;
    totalRecords: number;
    member: Member;
    organization: Organization;
    itemsPerPage = 10;
    toAssign: Assignee;
    issueId: number;
    IssueStatus = IssueStatus;
    IssueSelect = IssueSelect;
    selectedTabIssueStatus?: IssueStatus = IssueStatus.Active;
    selected: IssueSelect = IssueSelect.Active;
    issueStatusDropdownItems: IssueSelectDropdown[] = [];
    first: number = 0;
    private saveAssign: Assignee;
    private viewedAssignee = 3;

    constructor(
        private issuesHub: IssuesHubService,
        private issueService: IssueService,
        private toastNotification: ToastNotificationService,
        private authService: AuthenticationService,
        private memberService: MemberService,
        private teamService: TeamService,
        private spinner: SpinnerService,
        private tableExportService: TableExportService,
        private issueDropdownData: IssueDropdownDataService,
        private trelloService: TrelloService,
    ) {
        super();
    }

    ngOnInit(): void {
        this.isAssign = false;
        this.authService.getOrganization()
            .pipe(this.untilThis,
                switchMap(org => {
                    this.organization = org;
                    return this.authService.getMember();
                }), tap(member => {
                    this.member = member;
                })).subscribe(() => {
                forkJoin([this.loadMembers(), this.loadTeams()])
                    .pipe(this.untilThis)
                    .subscribe(([members, teams]) => {
                        this.sharedOptions.members = members;
                        this.sharedOptions.teams = teams;
                        this.loadIssuesLazy(this.lastEvent);
                        this.getIssuesCountByStatuses();
                        this.subscribeToIssuesHub();
                    });
            }, error => {
                this.toastNotification.error(error);
            });
        this.initIssueSelectDropdown();
    }

    loadMembers() {
        return this.memberService.getAssigneeMembers(this.member.organizationId)
            .pipe(this.untilThis);
    }

    loadTeams() {
        return this.teamService.getAssigneeTeams(this.member.organizationId)
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
                    if (this.organization.trelloIntegration) {
                        const issue = this.issues.find(i => i.issueId === this.issueId);
                        this.trelloService.addIssueToBoardWithAssignee(
                            issue,
                            toUsers(this.toAssign.memberIds, this.sharedOptions.members),
                            toTeams(this.toAssign.teamIds, this.sharedOptions.teams)
                        ).then(() => {
                            this.toastNotification.success('Trello card was updated!');
                        });
                    }
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

        this.issueService.getIssuesInfoLazy(this.member.id, this.lastEvent, this.selectedTabIssueStatus, this.project)
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

    getIssuesCountByStatuses(): void {
        this.issueService.getIssuesInfoCountByStatuses(this.member.id)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.setTabPanelFields(response);
            },
            error => {
                this.toastNotification.error(error);
            });
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

    getAllUsers(assignee: Assignee) {
        return toUsers(assignee.memberIds, this.sharedOptions.members);
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

    exportExcel(): void {
        this.spinner.show(true);
        this.tableExportService.exportExcel(
            this.issuesToExportIssues(this.selectedIssues.length ? this.selectedIssues : this.issues),
            'Issues'
        );
        this.spinner.hide();
    }

    exportPdf(): void {
        this.spinner.show(true);
        this.tableExportService.exportPdf(
            this.issuesToExportIssues(this.selectedIssues.length ? this.selectedIssues : this.issues),
            'Issues'
        );
        this.spinner.hide();
    }

    async onSelectedTab(index: number) {
        this.resetPageNumber();
        switch (index) {
            case 0:
                this.selectedTabIssueStatus = IssueStatus.Active;
                await this.loadIssuesLazy(this.lastEvent);
                break;
            case 1:
                this.selectedTabIssueStatus = IssueStatus.Resolved;
                await this.loadIssuesLazy(this.lastEvent);
                break;
            case 2:
                this.selectedTabIssueStatus = IssueStatus.Ignored;
                await this.loadIssuesLazy(this.lastEvent);
                break;
            case 3:
                this.selectedTabIssueStatus = undefined;
                await this.loadIssuesLazy(this.lastEvent);
                break;
            default:
                break;
        }
    }

    private resetPageNumber() {
        this.first = 0;
        this.lastEvent.first = 0;
    }

    async onSelectedIssues() {
        await this.onSelectedTab(this.selected);
    }

    private initIssueSelectDropdown() {
        this.issueStatusDropdownItems = this.issueDropdownData.getIssuesSelectDropdownItems();
    }

    private issuesToExportIssues(issuesToExport: IssueTableItem[]): IssueInfoExport[] {
        return issuesToExport.map<IssueInfoExport>(issue => (
            {
                ErrorClass: issue.errorClass,
                ErrorMessage: issue.errorMessage,
                Status: IssueStatus[issue.status],
                Events: issue.eventsCount,
                OccurredOn: new Date(issue.occurredOn).toLocaleString(),
                Affected: issue.affectedUsersCount,
                Project: issue.projectName,
                Assignee: this.getAllUsers(issue.assignee).map(value => `${value.firstName} ${value.lastName}`).join(' \r')
            }
        ));
    }

    private compareAssigns() {
        if (this.saveAssign.memberIds.length !== this.toAssign.memberIds.length) {
            return false;
        }
        if (this.saveAssign.teamIds.length !== this.toAssign.teamIds.length) {
            return false;
        }
        const before = {
            memberIds: this.saveAssign.memberIds.concat().sort((a, b) => a - b),
            teamIds: this.saveAssign.teamIds.concat().sort((a, b) => a - b)
        };
        const after = {
            memberIds: this.toAssign.memberIds.concat().sort((a, b) => a - b),
            teamIds: this.toAssign.teamIds.concat().sort((a, b) => a - b)
        };

        const equalsMembers = before.memberIds.every((item, index) => item === after.memberIds[index]);
        const equalsTeams = before.teamIds.every((item, index) => item === after.teamIds[index]);

        return equalsMembers && equalsTeams;
    }

    private subscribeToIssuesHub() {
        this.issuesHub.messages.pipe(this.untilThis)
            .subscribe(() => {
                this.loadIssuesLazy(this.lastEvent);
                this.getIssuesCountByStatuses();
            });
    }

    private setTabPanelFields(counts: CountOfIssuesByStatus) {
        this.issuesCount = {
            active: counts.activeCount,
            resolved: counts.resolvedCount,
            ignored: counts.ignoredCount,
            all: counts.activeCount + counts.resolvedCount + counts.ignoredCount,
        };
    }
}
