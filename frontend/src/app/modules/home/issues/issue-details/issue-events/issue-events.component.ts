import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { IssueService } from '@core/services/issue.service';
import { Router } from '@angular/router';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';

@Component({
    selector: 'app-issue-events[issueMessage]',
    templateUrl: './issue-events.component.html',
    styleUrls: ['./issue-events.component.sass']
})
export class IssueEventsComponent extends BaseComponent implements OnInit, OnDestroy {
    isLoading: boolean = true;
    @Input() issueMessage: IssueMessage;
    issues: IssueMessage[] = [];

    constructor(
        private issueService: IssueService,
        private router: Router,
        private toastNotificationService: ToastNotificationService,
    ) {
        super();
    }

    ngOnInit(): void {
        this.getIssuesMessages(this.issueMessage.issueId);
    }

    getIssuesMessages(parentId: string) {
        this.issueService.getIssueMessagesByParent(parentId)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.issues = response;
                this.isLoading = false;
            }, errorResponse => {
                this.toastNotificationService.error(errorResponse, '', 1500);
                this.isLoading = false;
            });
    }

    onIssueSelect(issue: IssueMessage) {
        if (issue.id === this.issueMessage.id) {
            this.toastNotificationService.info('You are already on the current issue page');
            return;
        }
        this.router.navigate([`home/issues/${issue.id}`]).then(r => r);
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
