import { Component, OnInit } from '@angular/core';
import { Member } from '@shared/models/member/member';
import { TestService } from '@core/services/test.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { SpinnerService } from '@core/services/spinner.service';
import { BaseComponent } from '@core/components/base/base.component';
import { hasAccess } from '@core/utils/access.utils';
import { ActivatedRoute, Router } from '@angular/router';
import { Test } from '@shared/models/test/test';
import { TestAnalytics } from '@shared/models/test/analytics/test-analytics';
import { OverlayPanel } from 'primeng/overlaypanel';

@Component({
    selector: 'app-test-result-page',
    templateUrl: './test-result-page.component.html',
    styleUrls: ['./test-result-page.component.sass']
})
export class TestResultPageComponent extends BaseComponent implements OnInit {
    isNotFound: boolean;
    member: Member;
    test: Test;

    testResult: TestAnalytics[];
    shownResults: TestAnalytics[];

    isNoContent: boolean = false;
    isLoading: boolean = false;
    hasAccess = () => hasAccess(this.member);

    constructor(
        private testService: TestService,
        private authService: AuthenticationService,
        private toastNotification: ToastNotificationService,
        private spinner: SpinnerService,
        private toastNotifications: ToastNotificationService,
        private activatedRoute: ActivatedRoute,
        private router: Router,
    ) { super(); }

    ngOnInit(): void {
        this.spinner.show(true);
        this.authService.getMember()
            .subscribe(member => {
                this.member = member;
                this.activatedRoute.params
                    .pipe(this.untilThis)
                    .subscribe(params => {
                        this.getTest(+params.id);
                    }, error => {
                        this.spinner.hide();
                        this.isNotFound = true;
                        this.toastNotification.error(error);
                    });
            }, error => {
                this.spinner.hide();
                this.isNotFound = true;
                this.toastNotification.error(error);
            });
    }

    getTest(id: number) {
        this.testService.getTestById(id)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.test = response;
                this.getTestResult(response.id);
                this.isNotFound = false;
                this.spinner.hide();
            }, error => {
                this.spinner.hide();
                this.isNotFound = true;
                this.toastNotification.error(error);
            });
    }

    filterResultsByUrl(result: TestAnalytics | undefined, panel: OverlayPanel) {
        if (result) {
            this.getTestResultByRequest(result.requestId);
        } else {
            this.shownResults = this.testResult;
        }
        panel.hide();
    }

    getTestResult(testId: number) {
        this.testService.getTestAnalyticsByTestId(testId)
            .pipe(this.untilThis)
            .subscribe(response => {
                console.log(response);
                this.testResult = response;
                this.shownResults = response;
            }, error => {
                this.isNoContent = true;
                this.toastNotification.error(error);
            });
    }

    getTestResultByRequest(requestId: number) {
        this.testService.getTestAnalyticsByRequestId(requestId)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.shownResults = [response];
            }, error => {
                this.isNoContent = true;
                this.toastNotification.error(error);
            });
    }

    deleteTest(testId: number) {
        this.spinner.show(true);
        this.testService.removeTestById(testId)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.toastNotification.success('Test removed!');
                this.router.navigateByUrl('home/tests').then(r => r);
            }, error => {
                this.toastNotification.error(error);
            });
    }

    runTest() {
        this.testService.updateTest(this.test, true).subscribe(() => {
            this.toastNotifications.success('Test run!');
        }, error => {
            this.toastNotifications.error(error);
        });
    }

    toggle(event: any, panel: OverlayPanel) {
        if (!panel.willHide) {
            panel.toggle(event);
        }
    }
}
