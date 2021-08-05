import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import firebase from 'firebase/app';

@Component({
    selector: 'app-user-password-settings',
    templateUrl: './user-password-settings.component.html',
    styleUrls: ['./user-password-settings.component.sass']
})

export class UserPasswordSettingsComponent implements OnInit {

    changePasswordForm: FormGroup;
    newPwdInputType: string;
    currentPwdInputType: string;

    constructor(
        private authService: AuthenticationService,
        private toastNotificationService: ToastNotificationService
    ) {
        this.newPwdInputType = "";
        this.currentPwdInputType = "";
    }

    ngOnInit() {
        this.changePasswordForm = new FormGroup({
            currentPassword: new FormControl(),
            newPassword: new FormControl()
        });
    }

    onSubmit() {
        const currentUser = this.authService.getFirebaseUser();
        const credentials = firebase.auth.EmailAuthProvider
            .credential(currentUser.email, this.changePasswordForm.value.currentPassword);

        currentUser.reauthenticateWithCredential(credentials)
            .then(() => {
                this.authService.updatePassword(this.changePasswordForm.value.newPassword);
                this.toastNotificationService.success('Password has been updated');
            })
            .catch(error => {
                console.warn(error);
                this.toastNotificationService.error('Current password is incorrect');
            });
    }

    changeCurrentPasswordVisibility() {
        this.currentPwdInputType = this.currentPwdInputType === 'text' ? 'password' : 'text';
    }

    changeNewPasswordVisibility() {
        this.newPwdInputType = this.newPwdInputType === 'text' ? 'password' : 'text';
    }
}
