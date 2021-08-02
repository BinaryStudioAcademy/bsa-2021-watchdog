import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BaseComponent } from '@core/components/base/base.component';
import { User } from '@core/models/user';
import { AuthService } from '@core/services/auth.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UserService } from '@core/services/user.service';
import { take } from 'rxjs/operators';

@Component({
    selector: 'app-user-password-settings',
    templateUrl: './user-password-settings.component.html',
    styleUrls: ['./user-password-settings.component.sass']
})

export class UserPasswordSettingsComponent extends BaseComponent implements OnInit {
    public user = {} as User;

    changePasswordForm: FormGroup;

    constructor(private authService: AuthService, private userService: UserService, private toastNotificationService: ToastNotificationService) {
        super();
        this.changePasswordForm = new FormGroup(
            {
                currentPassword: new FormControl(),
                newPassword: new FormControl()
            }
        );
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
        } else
            this.toastNotificationService.error('Current password is incorrect');
    }

    checkPassword(password: string): boolean {
        return password === this.user.password
    }

    changePasswordVisibility(button: HTMLElement) {
        const input: Element = button.previousElementSibling;
        const icon: Element = button.firstElementChild;
        let iconClass: string = 'pi pi pi-eye';
        let inputType: string = 'password';

        if (input.getAttribute('type') === 'password') {
            iconClass = 'pi pi-eye-slash';
            inputType = 'text';
        }
        icon.setAttribute('class', iconClass);
        input.setAttribute('type', inputType);
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
