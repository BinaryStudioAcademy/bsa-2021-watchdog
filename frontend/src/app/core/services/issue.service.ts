import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { IssueMessage } from '@shared/models/issues/issue-message';
import { IssueInfo } from '@shared/models/issues/issue.info';

@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: CoreHttpService) { }

    public getIssues() {
        return this.httpService.getRequest<IssueMessage[]>(`${this.routePrefix}`);
    }

    public getIssuesInfo() {
        return this.httpService.getRequest<IssueInfo[]>(`${this.routePrefix}/issues_info`);
    }
}
