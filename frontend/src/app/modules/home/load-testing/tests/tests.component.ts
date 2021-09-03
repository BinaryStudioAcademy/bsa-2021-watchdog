import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { TestService } from '@core/services/test.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Component, OnInit } from '@angular/core';
import { Test } from '@shared/models/test/test';

@Component({
    selector: 'app-tests',
    templateUrl: './tests.component.html',
    styleUrls: ['./tests.component.sass']
})
export class TestsComponent extends BaseComponent implements OnInit {
    tests: Test[];
    constructor(
        private testService: TestService,
        private authService: AuthenticationService,
        private toastNotification: ToastNotificationService
    ) { super(); }

    ngOnInit(): void {
        this.authService.getOrganization()
            .subscribe(organization => {
                this.testService.getTestsByOrganizationId(organization.id)
                    .subscribe(tests => {
                        this.tests = tests;
                    }, error => {
                        this.toastNotification.error(error);
                    });
            }, error => {
                this.toastNotification.error(error);
            });
    }
}
