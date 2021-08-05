import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserLoginDto } from '@core/models/auth/user-login';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.sass']
})
export class LoginFormComponent {
    public rememberMe: boolean;
    public user = {} as UserLoginDto;

    constructor(
        private authService: AuthenticationService,
        private router: Router
    ) { }

    onSubmit() {
        localStorage.setItem('rememberUser', JSON.stringify(this.rememberMe));
        this.authService.signInWithEmailAndPassword(this.user.email, this.user.password, ['home']);
    }

}
