import { Component, OnInit } from '@angular/core';
import { Option } from '@core/models/Option';
import { Issue } from '@shared/models/issue/issue';
import { IssueService } from '@core/services/issue.service';
import { IssueMessage } from '@shared/models/issues/issue-message';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-issues',
    templateUrl: './issues.component.html',
    styleUrls: ['./issues.component.sass']
})
export class IssuesComponent extends BaseComponent implements OnInit {
    issues: IssueMessage[];

    public countNew: { [type: string]: number };

    public sortedBy: Option;
    public sortedOptions: Option[];

    public selectedIssues: Issue[] = [];

    public timeOptions: string[];

    public selectedTime: string;

    constructor(private issueService: IssueService, private toastNotification: ToastNotificationService) {
        super();
    }

    ngOnInit(): void {
        this.loadIssues();
        this.setAllFieldsTemp();
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

    private loadIssues() {
        this.issueService.getIssues()
            .pipe(this.untilThis)
            .subscribe(response => {
                console.log(response.body);
                this.issues = response.body;
            }, errorResponse => {
                this.toastNotification.error(errorResponse, 'Error', 1500);
            });
    }

    private setAllFieldsTemp() {
        this.countNew = {
            all: 3,
            secondtype: 1,
            thirdtype: 0
        };

        this.sortedOptions = [
            {
                name: 'Last Seen',
                code: 'last-seen'
            },
            {
                name: 'Newest',
                code: 'newest'
            }
        ];

        [this.sortedBy] = this.sortedOptions;

        this.timeOptions = ['24h', '14d'];

        [this.selectedTime] = this.timeOptions;
    }
}
