import { Component, Input } from '@angular/core';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { Issue } from '@shared/models/issue/issue';

@Component({
    selector: 'app-issue-details[issue][issueMessage]',
    templateUrl: './issue-details.component.html',
    styleUrls: ['./issue-details.component.sass']
})
export class IssueDetailsComponent {
    @Input() issueMessage: IssueMessage;
    @Input() issue: Issue;
}
