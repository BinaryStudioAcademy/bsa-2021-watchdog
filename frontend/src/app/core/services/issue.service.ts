import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { Observable } from 'rxjs';
import { UpdateAssignee } from '@shared/models/issue/update-assignee';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { LazyLoadEvent } from 'primeng/api';
import { clear } from './members.utils';
import { clearIssueMessage, clearNest } from './issues.utils';
import { IssueMessageInfo } from '@shared/models/issue/issue-message-info';
import { UpdateIssueStatus } from '@shared/models/issue/update-issue-status';
import { Issue } from '@shared/models/issue/issue';
import { IssueStatusesFilter } from '@shared/models/issue/issue-statuses-filter';
import { IssueStatusesByDateRangeFilter } from '@shared/models/issue/issue-statuses-by-date-range-filter';

@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: CoreHttpService) { }

    public getIssuesInfo(memberId: number): Observable<IssueInfo[]> {
        return this.httpService.getRequest<IssueInfo[]>(`${this.routePrefix}/info/${memberId}`);
    }

    public getIssuesInfoLazy(memberId: number, event: LazyLoadEvent): Observable<{ collection: IssueInfo[], totalRecords: number }> {
        return this.httpService
            .postRequest(`${this.routePrefix}/info/${memberId}`, clear(event, clearNest));
    }

    public updateAssignee(updateData: UpdateAssignee): Observable<void> {
        return this.httpService.putRequest<void>(`${this.routePrefix}`, updateData);
    }
    public getIssueMessage(issueId: number, eventId: string): Observable<IssueMessage> {
        return this.httpService.getRequest<IssueMessage>(`${this.routePrefix}/issueId/${issueId}/eventId/${eventId}`);
    }

    public getEventMessagesByIssueId(issueId: number | string): Observable<IssueMessage[]> {
        return this.httpService.getRequest<IssueMessage[]>(`${this.routePrefix}/messagesbyparent/${issueId}`);
    }

    public getEventMessagesByIssueIdLazy(issueId: number | string, event: LazyLoadEvent):
    Observable<{ collection: IssueMessage[], totalRecords: number }> {
        return this.httpService.postRequest<{ collection: IssueMessage[], totalRecords: number }>(
            `${this.routePrefix}/messagesbyparent/${issueId}`,
            clear(event, clearIssueMessage)
        );
    }
    public getEventMessagesInfo(): Observable<IssueMessageInfo[]> {
        return this.httpService.getRequest<IssueMessageInfo[]>(`${this.routePrefix}/messages`);
    }

    public getEventMessagesInfoByProjectId(projectId: number): Observable<IssueMessageInfo[]> {
        return this.httpService.getRequest<IssueMessageInfo[]>(`${this.routePrefix}/messages/application/${projectId}`);
    }

    public getEventMessagesInfoByProjectIdFilteredByStatuses(
        projectId: number,
        issueStatusesFilter: IssueStatusesFilter
    ): Observable<IssueMessageInfo[]> {
        return this.httpService.postRequest<IssueMessageInfo[]>(
            `${this.routePrefix}/messages/application/${projectId}/filterbystatuses`,
            issueStatusesFilter
        );
    }

    public getFilteredIssueCountByStatusesAndDateRangeByApplicationId(
        projectId: number,
        issueFilter: IssueStatusesByDateRangeFilter
    ): Observable<number> {
        return this.httpService.postRequest<number>(
            `${this.routePrefix}/messages/application/${projectId}/filterbystatusesanddate`,
            issueFilter
        );
    }

    public updateIssueStatus(updateData: UpdateIssueStatus): Observable<void> {
        return this.httpService.putRequest<void>(`${this.routePrefix}/updatestatus`, updateData);
    }

    public getIssueById(issueId: number): Observable<Issue> {
        return this.httpService.getRequest<Issue>(`${this.routePrefix}/${issueId}`);
    }
}
