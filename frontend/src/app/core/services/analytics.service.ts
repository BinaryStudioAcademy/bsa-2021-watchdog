import { CoreHttpService } from '@core/services/core-http.service';
import { ResponseInfo } from '@shared/models/analytics/response-info';
import { Observable } from 'rxjs';
import { Project } from '@shared/models/projects/project';
import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';

@Injectable({ providedIn: 'root' })
export class AnalyticsService {
    public readonly routePrefix = '/analytics';

    constructor(private httpService: CoreHttpService) { }

    public getResponsesInfo(projects: Project[], dateRangeType: TileDateRangeType, count: number): Observable<ResponseInfo[]> {
        const params = new HttpParams()
            .set('count', count)
            .set('dateRangeType', dateRangeType);

        const keys = projects.map(p => p.apiKey);

        return this.httpService.postRequest<ResponseInfo[]>(`${this.routePrefix}/requestsInfo`, keys, params);
    }
}
