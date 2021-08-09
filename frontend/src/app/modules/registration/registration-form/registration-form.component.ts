import { Component, OnInit } from '@angular/core';
import { User } from '@shared/models/user/user';
import { Member } from '@shared/models/member/member'
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { OrganizationService } from '@core/services/organization.service';
import { NewOrganization } from '@shared/models/organization/newOrganization';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent extends BaseComponent implements OnInit {
    user = {} as User;
    member = {} as Member;
    organization = {} as NewOrganization;

    password: string;
    confirmPassword: string;
    rememberMe: boolean;

    constructor(
        private authService: AuthenticationService,
        private organizationService: OrganizationService
    ) {
        super();
    }

    ngOnInit(): void {
    }

    onSubmit() {
        this.authService.signOnWithEmailAndPassword(this.user, this.password, ['home'])
            .subscribe(() => {
                this.authService.getUser();
            });


        //console.log(this.organization);

        //this.organizationService.createOrganization(this.organization);
    }
}
