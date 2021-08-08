import { Component, OnInit } from '@angular/core';
import { User } from '@shared/models/user/user';
import { Role } from '@shared/models/role/role';
import { Member } from '@shared/models/member/member'
import { Organization } from '@shared/models/organization/organization';
import { AuthenticationService } from '@core/services/authentication.service';
import { RoleService } from '@core/services/role.service';
import { BaseComponent } from '@core/components/base/base.component';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent extends BaseComponent implements OnInit {
    public user = {} as User;
    public role: Role;
    public member = {} as Member; // TODO: needs implementation (public role: string;)
    public organization = {} as Organization;

    public password: string;
    public confirmPassword: string;
    public rememberMe: boolean;
    public organizationSize: string;

    public roles: Role[];
    public organizationSizes: { id: number, name: string }[];

    constructor(
        private authService: AuthenticationService,
        private roleService: RoleService
    ) {
        super();
    }

    ngOnInit(): void {
        this.roleService.getRoles()
            .pipe(this.untilThis)
            .subscribe((roles: Role[]) => {
                this.roles = roles;
            });

        this.organizationSizes = [
            { id: 1, name: '1-10' },
            { id: 2, name: '11-50' },
            { id: 3, name: '51-100' },
            { id: 4, name: '101-200' },
            { id: 5, name: '200+' }
        ];
    }

    onSubmit() {
        this.authService.signOnWithEmailAndPassword(this.user, this.password, ['home']);
    }
}
