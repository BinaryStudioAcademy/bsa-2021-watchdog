import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '@core/components/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';
import { IssueService } from '@core/services/issue.service';

import { ToastNotificationService } from '@core/services/toast-notification.service';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { switchMap } from 'rxjs/operators';

@Component({
    selector: 'app-issue-details-page',
    templateUrl: './issue-details-page.component.html',
    styleUrls: ['./issue-details-page.component.sass']
})
export class IssueDetailsPageComponent extends BaseComponent implements OnInit {
    issueMessage: IssueMessage;
    id: string;
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
        this.id = this.activatedRoute.snapshot.params.id;
        this.activatedRoute.paramMap.pipe(
            switchMap(params => params.getAll('id'))
        ).subscribe(data => {
            this.activeTabIndex = 0;
            this.id = data;
            this.getIssueMessage(this.id);
        });
    }

    getIssueMessage(id: string) {
        this.spinnerService.show(true);
        this.issueService.getIssueMessage(id)
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
