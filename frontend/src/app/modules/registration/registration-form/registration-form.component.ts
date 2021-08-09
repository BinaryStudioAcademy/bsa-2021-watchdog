import { Component, OnInit } from '@angular/core';
import { User } from '@shared/models/user/user';
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { NewOrganization } from '@shared/models/organization/newOrganization';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent extends BaseComponent implements OnInit {
    formGroup: FormGroup;
    user = {} as User;
    organization = {} as NewOrganization;

    password: string;
    confirmPassword: string;

    isNotFinishedRegistration = false;

    constructor(
        private authService: AuthenticationService,
        private toastService: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
        const user = this.authService.getUser();
        this.isNotFinishedRegistration = Boolean(user) && !user.registeredAt;
        if(this.isNotFinishedRegistration) {
            this.user = user;
        }

        const firstNamePattern = new RegExp(/^[a-zA-Z-]*$/);
        const lastNamePattern = new RegExp(/^[a-zA-Z- ]*$/);
        const organizationNamePattern = new RegExp('^[\\w\\s-!#$%&\'*+—/=?^`{|}~]+$');
        const emailPattern = new RegExp(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)
        const passwordPattern = new RegExp(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$/);
        this.formGroup = new FormGroup({
            firstName: new FormControl(
                {value: '', disabled: this.isNotFinishedRegistration},
                [
                    Validators.required,
                    Validators.minLength(2),
                    Validators.maxLength(20),
                    Validators.pattern(firstNamePattern)
                ]
            ),
            lastName: new FormControl(
                {value: '', disabled: this.isNotFinishedRegistration},
                [
                    Validators.required,
                    Validators.minLength(2),
                    Validators.maxLength(20),
                    Validators.pattern(lastNamePattern)
                ]
            ),
            organizationName: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(organizationNamePattern),
                ]
            ),
            email: new FormControl(
                {value: '', disabled: this.isNotFinishedRegistration},
                [
                    Validators.required,
                    Validators.minLength(5),
                    Validators.maxLength(30),
                    Validators.pattern(emailPattern)
                ]
            ),
            password: new FormControl(
                {value: '', disabled: this.isNotFinishedRegistration},
                [
                    Validators.required,
                    Validators.minLength(8),
                    Validators.maxLength(30),
                    Validators.pattern(passwordPattern)
                ]
            ),
            confirmPassword: new FormControl(
                {value: '', disabled: this.isNotFinishedRegistration},
                [
                    Validators.required,
                    Validators.minLength(8),
                    Validators.maxLength(30),
                    Validators.pattern(passwordPattern),
                    this.equals
                ]
            )
        });
        

    }

    equals = (control: AbstractControl) => {
        if (control.value !== this.password) {
            return {notEqual: true};
        }
    }

    onSubmit() {
        if(!this.isNotFinishedRegistration) {
            this.authService.signOnWithEmailAndPassword(this.user, this.password, ['home'])
            .subscribe(() => {
                this.authService.getUser();
            }, error => {
                this.toastService.error(`${error}`, 'Error', 2000);
            });
        } else {
            // Create organization + member
        }
    }
}
