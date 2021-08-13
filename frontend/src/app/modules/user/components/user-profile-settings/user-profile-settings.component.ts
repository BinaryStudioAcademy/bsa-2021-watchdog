import { AuthenticationService } from '@core/services/authentication.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@shared/models/user/user';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';
import { regexs } from '@shared/constants/regexs';

@Component({
    selector: 'app-user-profile-settings',
    templateUrl: './user-profile-settings.component.html',
    styleUrls: ['../user-profile/user-profile.component.sass']
})
export class UserProfileSettingsComponent extends BaseComponent implements OnInit {
    @Input() user: User;
    @Input() editForm: FormGroup;

    constructor(
        private authService: AuthenticationService,
        private userService: UserService,
        private toastNotificationService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.editForm.addControl('firstName', new FormControl(this.user.firstName, [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(30),
            Validators.pattern(regexs.firstName),
        ]));
        this.editForm.addControl('lastName', new FormControl(this.user.lastName, [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(30),
            Validators.pattern(regexs.lastName),
        ]));
        this.editForm.addControl('email', new FormControl(this.user.email, [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(50),
            Validators.pattern(regexs.email),
        ]));
        this.editForm.addControl('avatarUrl', new FormControl(this.user.avatarUrl));
    }

    get firstName() { return this.editForm.controls.firstName; }

    get lastName() { return this.editForm.controls.lastName; }

    get email() { return this.editForm.controls.email; }

    get avatarUrl() { return this.editForm.controls.avatarUrl; }
}
