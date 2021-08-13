import { Component } from '@angular/core';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-socials-login',
    templateUrl: './socials-login.component.html',
    styleUrls: ['./socials-login.component.sass']
})
export class SocialsLoginComponent {
    constructor(
        private authService: AuthenticationService,
        private toastService: ToastNotificationService
    ) { }

    signInWithGitHub() {
        this.authService.signInWithGitHub(['home'])
            .subscribe(() => { },
                error => {
                    this.toastService.error(`${error}`, 'Error');
                });
    }

    signInWithGoogle() {
        this.authService.signInWithGoogle(['home'])
            .subscribe(() => { },
                error => {
                    this.toastService.error(`${error}`, 'Error');
                });
    }

    signInWithFacebook() {
        this.authService.signInWithFacebook(['home'])
            .subscribe(() => { },
                error => {
                    this.toastService.error(`${error}`, 'Error');
                });
    }
}
