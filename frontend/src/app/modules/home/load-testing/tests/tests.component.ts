import { hasAccess } from '@core/utils/access.utils';
import { SpinnerService } from '../../../../core/services/spinner.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { TestService } from '@core/services/test.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Component, OnInit } from '@angular/core';
import { Test } from '@shared/models/test/test';
import { Member } from '@shared/models/member/member';

@Component({
    selector: 'app-tests',
    templateUrl: './tests.component.html',
    styleUrls: ['./tests.component.sass']
})
export class TestsComponent extends BaseComponent implements OnInit {
    tests: Test[];
    member: Member;

    hasAccess = () => hasAccess(this.member);

    constructor(
        private testService: TestService,
        private authService: AuthenticationService,
        private toastNotification: ToastNotificationService,
        private spinner: SpinnerService,
    ) { super(); }

    ngOnInit(): void {
        this.spinner.show(true);
        this.authService.getMember()
            .subscribe(member => {
                this.member = member;
                this.testService.getTestsByOrganizationId(member.organizationId)
                    .subscribe(tests => {
                        this.tests = tests;
                        this.spinner.hide();
                    }, error => {
                        this.spinner.hide();
                        this.toastNotification.error(error);
                    });
            }, error => {
                this.spinner.hide();
                this.toastNotification.error(error);
            });
    }
}
