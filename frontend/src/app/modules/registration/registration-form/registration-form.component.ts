import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Option } from '@core/models/Option';
import { UserSignOnDto } from '@core/models/registration/UserSignOnDto';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent implements OnInit {
    public roles: Option[];
    public companySize: Option[];
    public user = {} as UserSignOnDto;
    public rememberMe: boolean;
    public confirmPassword: string;

    constructor(private authService: AuthenticationService, private router: Router) { }

    ngOnInit(): void {
        this.roles = [
            { name: 'frontend-dev', code: 'fd' },
            { name: 'backend-dev', code: 'bd' },
            { name: 'devOps', code: 'do' },
        ];
        this.companySize = [
            { name: '1-10', code: 'ten' },
            { name: '11-50', code: 'fifty' },
            { name: '51-100', code: 'hundred' },
            { name: '101-200', code: 'twohundred' },
            { name: '200+', code: 'more' }
        ];
    }

    onSubmit() {
        this.authService.signOnWithEmailAndPassword(this.user.email, this.user.password, ['home']);
    }
}
