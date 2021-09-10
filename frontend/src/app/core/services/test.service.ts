import { Injectable } from '@angular/core';
import { Test } from '@shared/models/test/test';
import { Observable } from 'rxjs';
import { CoreHttpService } from './core-http.service';
import { TestAnalytics } from '@shared/models/test/analytics/test-analytics';

@Injectable({
    providedIn: 'root'
})
export class TestService {
    private apiPrefix = '/loadertests';

    constructor(
        private httpService: CoreHttpService
    ) { }

    createTest(test: Test, start: boolean): Observable<Test> {
        return this.httpService.postRequest(`${this.apiPrefix}`, test, { start });
    }

    updateTest(test: Test, start: boolean): Observable<Test> {
        return this.httpService.putRequest(`${this.apiPrefix}`, test, { start });
    }

    getTestsByOrganizationId(organizationId: number): Observable<Test[]> {
        return this.httpService.getRequest(`${this.apiPrefix}/organization/${organizationId}`);
    }

    getTestById(id: number): Observable<Test> {
        return this.httpService.getRequest(`${this.apiPrefix}/${id}`);
    }

    getTestAnalyticsByTestId(testId: number): Observable<TestAnalytics[]> {
        return this.httpService.getRequest(`${this.apiPrefix}/${testId}/resultsanalytics`);
    }

    getTestAnalyticsByRequestId(requestId: number): Observable<TestAnalytics> {
        return this.httpService.getRequest(`${this.apiPrefix}/request/${requestId}/resultanalytics`);
    }

    removeTestById(testId: number) {
        return this.httpService.deleteRequest(`${this.apiPrefix}/${testId}`);
    }
}
