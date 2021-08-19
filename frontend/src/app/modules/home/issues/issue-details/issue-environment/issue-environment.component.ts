import { Component, Input } from '@angular/core';
import { IssueEnvironment } from '@shared/models/issue/issue-environment';

@Component({
    selector: 'app-issue-environment[issueEnvironment]',
    templateUrl: './issue-environment.component.html',
    styleUrls: ['./issue-environment.component.sass']
})
export class IssueEnvironmentComponent {
    @Input() issueEnvironment: IssueEnvironment;
}
