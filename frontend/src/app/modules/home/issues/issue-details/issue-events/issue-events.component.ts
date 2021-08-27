import { Component, Input, OnDestroy } from '@angular/core';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { IssueService } from '@core/services/issue.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { LazyLoadEvent } from 'primeng/api';

@Component({
    selector: 'app-issue-events[issueMessage]',
    templateUrl: './issue-events.component.html',
    styleUrls: ['./issue-events.component.sass']
})
export class IssueEventsComponent extends BaseComponent implements OnDestroy {
    @Input() issueMessage: IssueMessage;
    issues: IssueMessage[] = [];
    paginatorRows: number = 9;
    lastEvent: LazyLoadEvent;
    loading: boolean = false;
    totalRecords: number;

    constructor(
        private issueService: IssueService,
        private toastNotificationService: ToastNotificationService,
    ) {
        super();
    }

    async getEventMessages(event: LazyLoadEvent) {
        this.loading = true;
        this.issueService.getEventMessagesByIssueIdLazy(this.issueMessage.issueId, event)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.issues = response.collection;
                this.totalRecords = response.totalRecords;
                this.loading = false;
            }, errorResponse => {
                this.toastNotificationService.error(errorResponse);
                this.loading = false;
            });
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
