import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: CoreHttpService) { }

    public getIssuesInfo(): Observable<IssueInfo[]> {
        return this.httpService.getRequest<IssueInfo[]>(`${this.routePrefix}/info`);
    }

    public getIssueMessage(id: string): Observable<IssueMessage> {
        return this.httpService.getRequest<IssueMessage>(`${this.routePrefix}/message/${id}`);
    }

    public getIssueMessagesByParent(parentIssueId: string): Observable<IssueMessage[]> {
        return this.httpService.getRequest<IssueMessage[]>(`${this.routePrefix}/messagesbyparent/${parentIssueId}`);
    }
}
