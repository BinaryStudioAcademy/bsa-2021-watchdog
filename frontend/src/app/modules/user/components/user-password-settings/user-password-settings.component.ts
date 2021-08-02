import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@core/models/user';
import { AuthService } from '@core/services/auth.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';

@Component({
    selector: 'app-user-password-settings',
    templateUrl: './user-password-settings.component.html',
    styleUrls: ['./user-password-settings.component.sass']
})

export class UserPasswordSettingsComponent extends BaseComponent implements OnInit, OnDestroy {
    public user = {} as User;

    changePasswordForm: FormGroup;
    newPwdInputType: string;
    currentPwdInputType: string;

    constructor(private authService: AuthService, private userService: UserService,
        private toastNotificationService: ToastNotificationService) {
        super();
        this.changePasswordForm = new FormGroup(
            {
                currentPassword: new FormControl(),
                newPassword: new FormControl()
            }
        );
        this.newPwdInputType = 'password';
        this.currentPwdInputType = 'password';
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();
    }

    submit(editForm) {
        if (this.checkPassword(editForm.value.currentPassword)) {
            this.user.password = editForm.value.newPassword;
            this.userService.updateUser(this.user)
                .pipe(this.untilThis)
                .subscribe(resp => {
                    this.authService.setUser(resp.body);
                    this.toastNotificationService.success('Password has been updated');
                });
        } else {
            this.toastNotificationService.error('Current password is incorrect');
        }
    }

    checkPassword(password: string): boolean {
        return password === this.user.password;
    }

    changeCurrentPasswordVisibility() {
        this.currentPwdInputType = this.currentPwdInputType === 'text' ? 'password' : 'text';
    }

    changeNewPasswordVisibility() {
        this.newPwdInputType = this.newPwdInputType === 'text' ? 'password' : 'text';
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
