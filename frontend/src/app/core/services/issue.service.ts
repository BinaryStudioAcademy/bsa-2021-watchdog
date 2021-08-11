import { Injectable } from '@angular/core';
import { HttpInternalService } from '@core/services/http-internal.service';
import { IssueMessage } from '@shared/models/issues/issue-message';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class IssueService {
    public readonly routePrefix = '/issues';

    constructor(private httpService: HttpInternalService) { }

    public getIssues(): Observable<HttpResponse<IssueMessage[]>> {
        return this.httpService.getFullRequest(`${this.routePrefix}`);
    }
}
