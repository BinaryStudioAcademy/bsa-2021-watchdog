import { Component, OnInit } from '@angular/core';
import { User } from '@shared/models/user/user';
import { Member } from '@shared/models/member/member'
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { NewOrganization } from '@shared/models/organization/newOrganization';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent extends BaseComponent implements OnInit {
    user = {} as User;
    member = {} as Member;
    organization = {} as NewOrganization;

    password: string;
    confirmPassword: string;
    rememberMe: boolean;

    constructor(
        private authService: AuthenticationService,
        private toastService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
    }

    onSubmit() {
        this.authService.signOnWithEmailAndPassword(this.user, this.password, ['home'])
            .subscribe(() => {
                this.authService.getUser();
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
    }
}
