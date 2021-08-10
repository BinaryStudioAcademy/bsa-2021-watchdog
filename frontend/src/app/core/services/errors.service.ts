import { Injectable, OnDestroy } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { IssueMessage } from '@shared/models/issues/issue-message';
import * as stackTraceParser from 'stacktrace-parser';
import { HttpInternalService } from '@core/services/http-internal.service';
import { StackTrace } from '@shared/models/issues/stack-trace';
import { IssueEnvironment } from '@shared/models/issues/issue-environment';
import { HttpResponseErrorMessage } from '@shared/models/issues/http-response.message';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { ToastNotificationService } from './toast-notification.service';

@Injectable({
    providedIn: 'root'
})
export class ErrorsService implements OnDestroy {
    private unsubscribe$: Subject<void> = new Subject<void>();

    constructor(private httpService: HttpInternalService, private toastNotification: ToastNotificationService) { }

    log(error: any) {
        const issueMessage = this.addContextInfo(error);
        console.log(issueMessage);
        this.httpService.postFullRequest('http://localhost:5090/issues', issueMessage)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(() => {
                this.toastNotification.info('Sent error to collector.', null, 1700);
            }, () => {
                this.toastNotification.info('Are you sure that collector is running?', null, 1700);
            });
    }

    private addContextInfo(error: any): IssueMessage {
        return {
            occurredOn: new Date(),
            issueDetails: {
                url: window.location.href,
                errorMessage: error.message === '' ? 'Script error' : error.message,
                className: error.name,
                stackTrace: error instanceof Error ? this.getStackTrace(error) : null,
                responseErrorMessage: error instanceof HttpErrorResponse ? this.getResponseErrorMessage(error) : null,
                environmentMessage: this.getEnvironment()
            }
        };
    }

    private getStackTrace(error: Error): StackTrace[] {
        const parsedStackTrace = stackTraceParser.parse(error.stack);

        return parsedStackTrace.map(item => ({ ...item }));
    }

    private getResponseErrorMessage(error: HttpErrorResponse): HttpResponseErrorMessage {
        return {
            message: error.message,
            url: error.url,
            status: error.status,
            statusText: error.statusText
        };
    }

    private getEnvironment(): IssueEnvironment {
        return {
            browser: navigator.appCodeName,
            browserName: navigator.appName,
            browserVersion: navigator.appVersion,
            platform: navigator.platform
        };
    }

    ngOnDestroy(): void {
        this.unsubscribe$.next();
        this.unsubscribe$.unsubscribe();
    }
}
