import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { TopIssuesInfo } from '@shared/models/issue/top-issues.info';
import { Issue } from '@shared/models/issue/issue';

@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: CoreHttpService) { }

    public getIssues() {
        return this.httpService.getRequest<Issue[]>(`${this.routePrefix}`);
    }

    public getTopIssues() {
        return this.httpService.getRequest<TopIssuesInfo[]>(`${this.routePrefix}/topIssues`);
    }
}
