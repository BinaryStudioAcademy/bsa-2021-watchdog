import { Component } from '@angular/core';
import { UserLoginDto } from '@core/models/auth/user-login';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.sass']
})
export class LoginFormComponent {
    public rememberMe : boolean;
    public user = {} as UserLoginDto;
}
