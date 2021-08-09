import { Component } from '@angular/core';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.sass']
})
export class LoginFormComponent {
    public rememberMe: boolean;
    public email: string;
    public password: string;

    constructor(
        private authService: AuthenticationService
    ) { }

    onSubmit() {
        localStorage.setItem('rememberUser', JSON.stringify(this.rememberMe));
        this.authService.signInWithEmailAndPassword(this.email, this.password, ['home'])
            .subscribe(() => { });
    }

}
