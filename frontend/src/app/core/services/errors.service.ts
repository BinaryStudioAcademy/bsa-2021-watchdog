import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { IssueMessage } from '@shared/models/issues/issue-message';
import * as stackTraceParser from 'stacktrace-parser';
import { HttpInternalService } from '@core/services/http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class ErrorsService {
    constructor(private httpService: HttpInternalService) { }

    log(error: any) {
        console.error(error);
        const issueMessage = this.addContextInfo(error);
        console.log(issueMessage);
        this.httpService.postFullRequest('http://localhost:5090/issues', issueMessage)
            .subscribe();
    }

    private addContextInfo(error: any): IssueMessage {
        return {
            occurredOn: new Date(),
            issueDetails: {
                url: window.location.href,
                errorMessage: error.message === '' ? 'Script error' : error.message,
                className: error.name,
                stackTrace: error instanceof Error ? stackTraceParser.parse(error.stack) : null,
                responseErrorMessage: error instanceof HttpErrorResponse ? {
                    message: error.message,
                    url: error.url,
                    status: error.status,
                    statusText: error.statusText
                } : null,
                environmentMessage: {
                    browser: navigator.appCodeName,
                    browserName: navigator.appName,
                    browserVersion: navigator.appVersion,
                    platform: navigator.platform
                }
            }
        };
    }
}
