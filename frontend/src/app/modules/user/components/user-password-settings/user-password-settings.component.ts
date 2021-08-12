import { Component } from '@angular/core';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import firebase from 'firebase/app';

@Component({
    selector: 'app-user-password-settings',
    templateUrl: './user-password-settings.component.html',
    styleUrls: ['../user-profile/user-profile.component.sass']
})

export class UserPasswordSettingsComponent {
    public oldPassword: string;
    public newPasswordRepeat: string;
    public newPassword: string;

    constructor(
        private authService: AuthenticationService,
        private toastNotificationService: ToastNotificationService
    ) { }

    onSubmit() {
        if (this.newPassword === this.newPasswordRepeat) {
            const { currentUser } = firebase.auth();
        const credentials = firebase.auth.EmailAuthProvider
            .credential(currentUser.email, this.oldPassword);

        currentUser.reauthenticateWithCredential(credentials)
            .then(() => {
                this.authService.updatePassword(this.newPassword);
                this.toastNotificationService.success('Password has been updated');
            })
            .catch(error => {
                console.warn(error);
                this.toastNotificationService.error('Current password is incorrect');
            });
        }
        else {
            this.toastNotificationService.error('Input correct new password');
        }

    }
}
