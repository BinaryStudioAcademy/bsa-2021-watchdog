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
    organization = {} as NewOrganization;

    password: string;
    confirmPassword: string;

    isNotFinishedRegistration = false;

    constructor(
        private authService: AuthenticationService,
        private organizationService: OrganizationService
    ) {
        super();
    }

    ngOnInit(): void {
        const user = this.authService.getUser();
        this.isNotFinishedRegistration = Boolean(user) && !user.registeredAt;
        if(this.isNotFinishedRegistration) {
            this.user = user;
        }
    }

    onSubmit() {
        if(!this.isNotFinishedRegistration) {
            this.authService.signOnWithEmailAndPassword(this.user, this.password, ['home'])
            .subscribe();
        } else {
            // Create organization + member
        }

    }
}
