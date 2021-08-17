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

    numberOfIssues = 0;

    itemsPerPage = 10;

    constructor(private issueService: IssueService, private toastNotification: ToastNotificationService) {
        super();
    }

    ngOnInit(): void {
        //this.loadIssues();
        this.setAllFieldsTemp();
        this.loads()
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
        this.paginators = this.numberOfIssues > this.itemsPerPage;
    }

    // private loadIssues() {
    //     this.issueService.getIssuesInfo()
    //         .pipe(this.untilThis)
    //         .subscribe(issues => {
    //             this.issues = issues;
    //             this.numberOfIssues = issues.length;
    //         }, errorResponse => {
    //             this.toastNotification.error(errorResponse, 'Error', 1500);
    //         });
    // }

    private loads() {
        return this.issueService.getIssuesInfo()
            .pipe(
                tap(issues => {
                    this.issues = issues;
                    this.numberOfIssues = issues.length;
                }),
                catchError(error => of(this.toastNotification.error(error, 'Error', 1500)))
            )
    }

    private setAllFieldsTemp() {
        this.countNew = {
            all: 3,
            secondtype: 1,
            thirdtype: 0
        };
    }
}
