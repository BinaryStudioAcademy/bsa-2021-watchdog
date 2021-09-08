import { AuthenticationService } from '@core/services/authentication.service';
import { hasAccess } from '@core/utils/access.utils';
import { Member } from '@shared/models/member/member';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '@core/components/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';
import { IssueService } from '@core/services/issue.service';

import { ToastNotificationService } from '@core/services/toast-notification.service';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { regexs } from '@shared/constants/regexs';
import { Issue } from '@shared/models/issue/issue';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { IssueSolutionItem } from '@shared/models/issue/issue-solution/issue-solution-item';
import { IssueStatusDropdown } from '@shared/modules/issues/data/models/issue-status.dropdown';
import { IssueDropdownDataService } from '@shared/modules/issues/data/issue-dropdown-data.service';

@Component({
    selector: 'app-issue-details-page',
    templateUrl: './issue-details-page.component.html',
    styleUrls: ['./issue-details-page.component.sass'],
    providers: [IssueDropdownDataService]
})
export class IssueDetailsPageComponent extends BaseComponent implements OnInit {
    issueMessage: IssueMessage;
    issue: Issue;
    activeTabIndex: number = 0;
    isNotFound: boolean = false;
    issueStatusDropdownItems: IssueStatusDropdown[] = [];
    IssueStatus = IssueStatus;
    selected: IssueStatus;
    isLoadingStatus: boolean = false;
    solutionItems: IssueSolutionItem[] = [];
    member: Member;

    hasAccess = () => hasAccess(this.member);

    constructor(
        private activatedRoute: ActivatedRoute,
        private spinnerService: SpinnerService,
        private issueService: IssueService,
        private toastNotification: ToastNotificationService,
        private issueDropdownData: IssueDropdownDataService,
        private authService: AuthenticationService
    ) {
        super();
        this.spinnerService.show(true);
    }

    ngOnInit() {
        this.initIssueStatusDropdown();
        this.authService.getMember().pipe(this.untilThis)
            .subscribe(member => {
                this.member = member;
                this.activatedRoute.paramMap.pipe(this.untilThis)
                    .subscribe(param => {
                        this.activeTabIndex = 0;
                        const eventId: string = param.get('eventId');
                        const issueId: number = +param.get('issueId');
                        if (eventId.match(regexs.issueEventIdGuid)) {
                            if (this.issue?.id !== issueId) {
                                this.getIssueWithMessageById(issueId, eventId);
                            } else {
                                this.getIssueMessage(issueId, eventId);
                            }
                        } else {
                            this.isNotFound = true;
                            this.spinnerService.hide();
                        }
                        this.getSolutions(issueId);
                    });
            }, error => {
                this.toastNotification.error(error);
            });
    }

    getIssueMessage(issueId: number, eventId: string) {
        this.spinnerService.show(true);
        this.issueService.getIssueMessage(issueId, eventId)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.spinnerService.hide();
                this.issueMessage = response;
            }, errorResponse => {
                this.spinnerService.hide();
                this.isNotFound = true;
                this.toastNotification.error(errorResponse);
            });
    }

    getIssueWithMessageById(issueId: number, eventId: string) {
        this.spinnerService.show(true);
        this.issueService.getIssueById(issueId)
            .pipe(this.untilThis)
            .subscribe(response => {
                if (response.project.organizationId !== this.member.organizationId) {
                    this.isNotFound = true;
                    this.spinnerService.hide();
                } else {
                    this.issue = response;
                    this.selected = response.status;
                    this.getIssueMessage(response.id, eventId);
                }
            }, () => {
                this.isNotFound = true;
                this.spinnerService.hide();
            });
    }

    updateIssueStatusById(issueId: number, issueStatus: IssueStatus) {
        this.isLoadingStatus = true;
        this.issueService.updateIssueStatus({ status: issueStatus, issueId })
            .pipe(this.untilThis)
            .subscribe(() => {
                this.isLoadingStatus = false;
                this.toastNotification.success('Status changed', '', 500);
            },
            error => {
                this.isLoadingStatus = false;
                this.toastNotification.error(error);
            });
    }

    initIssueStatusDropdown() {
        this.issueStatusDropdownItems = this.issueDropdownData.getIssueStatusDropdownItems();
    }

    onSelectedIssueStatus() {
        this.updateIssueStatusById(this.issue.id, this.selected);
    }

    getSolutions(issueId: number): void {
        this.issueService.getSolutionLink(issueId)
            .pipe(this.untilThis)
            .subscribe(solution => { this.solutionItems = solution?.items; });
    }
}
