import { Component, Input } from '@angular/core';
import { HttpResponseErrorMessage } from '@shared/models/issue/http-response.message';

@Component({
    selector: 'app-issue-http[issueHttpResponse]',
    templateUrl: './issue-http.component.html',
    styleUrls: ['./issue-http.component.sass']
})
export class IssueHttpComponent {
    @Input() issueHttpResponse: HttpResponseErrorMessage;
}
