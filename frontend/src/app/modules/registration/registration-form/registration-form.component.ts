import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Member } from '@core/models/member';
import { Option } from '@core/models/Option';
import { Organization } from '@core/models/organization';
import { User } from '@core/models/user';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent implements OnInit {
    public user = {} as User;
    public member = {} as Member; // TODO: needs implementation (public role: string;)
    public organization = {} as Organization;

    public password: string;
    public confirmPassword: string;
    public rememberMe: boolean;
    public role: string;

    public roles: Option[];
    public organizationSizes: Option[];

    constructor(private authService: AuthenticationService) { }

    ngOnInit(): void {
        this.roles = [
            { name: 'frontend-dev', code: 'fd' },
            { name: 'backend-dev', code: 'bd' },
            { name: 'devOps', code: 'do' },
        ];
        this.organizationSizes = [
            { name: '1-10', code: 'ten' },
            { name: '11-50', code: 'fifty' },
            { name: '51-100', code: 'hundred' },
            { name: '101-200', code: 'twohundred' },
            { name: '200+', code: 'more' }
        ];
    }

    onSubmit() {
        this.authService.signOnWithEmailAndPassword(this.user, this.password, ['home']);
    }
}
