import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { regexs } from '@shared/constants/regexs';

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
        this.formGroup = new FormGroup({
            email: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(6),
                    Validators.pattern(regexs.email)
                ]
            ),
            password: new FormControl(
                '',
                [
                    Validators.required
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
