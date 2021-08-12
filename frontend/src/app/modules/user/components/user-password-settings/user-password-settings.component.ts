import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { regexs } from '@shared/constants/regexs';
import { User } from '@shared/models/user/user';

@Component({
    selector: 'app-user-password-settings',
    templateUrl: './user-password-settings.component.html',
    styleUrls: ['../user-profile/user-profile.component.sass']
})

export class UserPasswordSettingsComponent {
    //public oldPassword: string;
    //public newPasswordRepeat: string;
    //public newPassword: string;

    @Input() user: User;

    @Input() pass: FormGroup;

    constructor(
        private authService: AuthenticationService,
        private toastNotificationService: ToastNotificationService
    ) { }

    ngOnInit(): void {
        this.pass.addControl('oldPassword', new FormControl(null, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
        ]));
        this.pass.addControl('newPassword', new FormControl(null, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
        ]));
        this.pass.addControl('confirmPassword', new FormControl(null));
    }

    get oldPassword() { return this.pass.controls.oldPassword; }

    get newPassword() { return this.pass.controls.newPassword; }

    get confirmPassword() { return this.pass.controls.confirmPassword; }

}
