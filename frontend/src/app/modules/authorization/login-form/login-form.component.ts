import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.sass']
})
export class LoginFormComponent implements OnInit {
    formGroup: FormGroup;
    public rememberMe: boolean;
    public email: string;
    public password: string;

    constructor(
        private authService: AuthenticationService,
        private toastService: ToastNotificationService
    ) { }

    ngOnInit(): void {
        const emailPattern = new RegExp(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
        const passwordPattern = new RegExp(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$/);
        this.formGroup = new FormGroup({
            email: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(5),
                    Validators.maxLength(30),
                    Validators.pattern(emailPattern)
                ]
            ),
            password: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(8),
                    Validators.maxLength(30),
                    Validators.pattern(passwordPattern)
                ]
            ),
            rememberMe: new FormControl(
                ''
            ),
        });
    }

    onSubmit() {
        localStorage.setItem('rememberUser', JSON.stringify(this.rememberMe));
        this.authService.signInWithEmailAndPassword(this.email, this.password, ['home'])
            .subscribe(() => { },
                error => {
                    this.toastService.error(`${error}`, 'Error');
                });
    }
}
