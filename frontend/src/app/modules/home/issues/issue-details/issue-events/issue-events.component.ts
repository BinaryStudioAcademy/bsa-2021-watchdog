import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { IssueService } from '@core/services/issue.service';
import { Router } from '@angular/router';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-issue-events[issueMessage]',
    templateUrl: './issue-events.component.html',
    styleUrls: ['./issue-events.component.sass']
})
export class IssueEventsComponent extends BaseComponent implements OnInit, OnDestroy {
    @Input() issueMessage: IssueMessage;
    issues: IssueMessage[] = [];
    paginatorRows: number = 9;

    constructor(
        private issueService: IssueService,
        private router: Router,
        private toastNotificationService: ToastNotificationService,
        private spinnerService: SpinnerService
    ) {
        super();
        this.spinnerService.show(true);
    }

    ngOnInit(): void {
        this.getIssuesMessages(this.issueMessage.issueId);
    }

    getIssuesMessages(parentId: string) {
        this.issueService.getIssueMessagesByParent(parentId)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.issues = response;
                this.spinnerService.hide();
            }, errorResponse => {
                this.toastNotificationService.error(errorResponse, '', 1500);
                this.spinnerService.hide();
            });
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
