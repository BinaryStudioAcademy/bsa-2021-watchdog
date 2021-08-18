import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { Observable } from 'rxjs';
import { UpdateAssignee } from '@shared/models/issue/updateAssignee'
@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: CoreHttpService) { }

    public getIssuesInfo() {
        return this.httpService.getRequest<IssueInfo[]>(`${this.routePrefix}/info`);
    }

    public updateAssignee(updateData: UpdateAssignee): Observable<void> {
        return this.httpService.putRequest<void>(`${this.routePrefix}`, updateData);
    }
}

