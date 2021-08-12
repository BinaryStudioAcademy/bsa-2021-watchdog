import { Injectable } from '@angular/core';
import { HttpInternalService } from '@core/services/http-internal.service';
import { IssueMessage } from '@shared/models/issues/issue-message';

@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: HttpInternalService) { }

    public getIssues() {
        return this.httpService.getRequest<IssueMessage[]>(`${this.routePrefix}`);
    }
}
