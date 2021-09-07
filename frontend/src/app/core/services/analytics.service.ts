import { CoreHttpService } from '@core/services/core-http.service';
import { ResponseInfo } from '@shared/models/analytics/response-info';
import { Observable } from 'rxjs';
import { Project } from '@shared/models/projects/project';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AnalyticsService {
    public readonly routePrefix = '/analytics';

    constructor(private httpService: CoreHttpService) { }

    public getResponsesInfo(projects: Project[], count: number): Observable<ResponseInfo[]> {
        return this.httpService.postRequest<ResponseInfo[]>(`${this.routePrefix}/requestsInfo`, projects, { count });
    }
}
