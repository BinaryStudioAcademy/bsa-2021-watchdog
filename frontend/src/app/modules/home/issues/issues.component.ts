import { Component, OnInit } from '@angular/core';
import { IssueService } from '@core/services/issue.service';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent extends BaseComponent implements OnInit {
    issues: IssueInfo[] = [];

    countNew: { [type: string]: number };

    selectedIssues: IssueInfo[] = [];

    timeOptions: string[];

    selectedTime: string;

    paginators = false;

    itemsPerPage = 10;

    constructor(private issueService: IssueService, private toastNotification: ToastNotificationService) {
        super();
    }

    ngOnInit(): void {
        this.setAllFieldsTemp();
        this.loadIssues()
            .pipe(this.untilThis)
            .subscribe(() => {
                this.showPaginator();
            });
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

    private showPaginator() {
        this.paginators = this.issues.length > this.itemsPerPage;
    }

    private loadIssues() {
        return this.issueService.getIssuesInfo()
            .pipe(
                tap(issues => {
                    this.issues = issues;
                }),
                catchError(error => of(this.toastNotification.error(error, 'Error', 1500)))
            );
    }

    private setAllFieldsTemp() {
        this.countNew = {
            all: 3,
            secondtype: 1,
            thirdtype: 0
        };
    }
}
