import { Component, Input } from '@angular/core';
import { IssueMessage } from '@shared/models/issue/issue-message';

@Component({
    selector: 'app-issue-details[issueMessage]',
    templateUrl: './issue-details.component.html',
    styleUrls: ['./issue-details.component.sass']
})
export class IssueDetailsComponent {
    @Input() issueMessage: IssueMessage;
}
