import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { Issue } from '@shared/models/issue/issue';
import { IssueInfo } from '@shared/models/issue/issue-info';

@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: CoreHttpService) { }

    public getIssue(errorMessage: string) {
        return this.httpService.getRequest<Issue>(`${this.routePrefix}?errorMessage=${errorMessage}`);
    }

    public getIssuesInfo() {
        return this.httpService.getRequest<IssueInfo[]>(`${this.routePrefix}/info`);
    }
}
