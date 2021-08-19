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
    issueMessage: IssueMessage = undefined;
    id: string;
    requiredIdLength = 20;
    isLoading: boolean = true;
    activeTabIndex: number = 0;

    constructor(
        private activatedRoute: ActivatedRoute,
        private spinnerService: SpinnerService,
        private issueService: IssueService,
        private toastNotification: ToastNotificationService,
    ) {
        super();
    }

    ngOnInit() {
        this.id = this.activatedRoute.snapshot.params.id;
        this.activatedRoute.paramMap.pipe(
            switchMap(params => params.getAll('id'))
        ).subscribe(data => {
            this.activeTabIndex = 0;
            this.id = data;
            if (!this.isValidId(this.id)) {
                this.isLoading = false;
                this.toastNotification.error('Issue id is not valid');
                this.issueMessage = undefined;
                return;
            }
            this.getIssueMessage(this.id);
        });
    }

    getIssueMessage(id: string) {
        this.isLoading = true;
        this.issueService.getIssueMessage(id)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.isLoading = false;
                this.issueMessage = response;
            }, errorResponse => {
                this.isLoading = false;
                this.toastNotification.error(errorResponse);
            });
    }

    isValidId(id: string): boolean {
        return id.length === this.requiredIdLength;
    }
}
