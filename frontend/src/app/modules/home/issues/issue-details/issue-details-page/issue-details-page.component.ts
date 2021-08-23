import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '@core/components/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';
import { IssueService } from '@core/services/issue.service';

import { ToastNotificationService } from '@core/services/toast-notification.service';
import { IssueMessage } from '@shared/models/issue/issue-message';

@Component({
    selector: 'app-issue-details-page',
    templateUrl: './issue-details-page.component.html',
    styleUrls: ['./issue-details-page.component.sass']
})
export class IssueDetailsPageComponent extends BaseComponent implements OnInit {
    issueMessage: IssueMessage;
    activeTabIndex: number = 0;
    isNotFound: boolean = false;

    constructor(
        private activatedRoute: ActivatedRoute,
        private spinnerService: SpinnerService,
        private issueService: IssueService,
        private toastNotification: ToastNotificationService,
    ) {
        super();
        this.spinnerService.show(true);
    }

    ngOnInit() {
        this.activatedRoute.paramMap.pipe(this.untilThis)
            .subscribe(param => {
                this.activeTabIndex = 0;
                this.getIssueMessage(+param.get('issueId'), param.get('eventId'));
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
}
