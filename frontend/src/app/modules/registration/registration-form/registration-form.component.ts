import { Component, OnInit } from '@angular/core';
import { User } from '@shared/models/user/user';
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { NewOrganization } from '@shared/models/organization/newOrganization';
import { NewOrganizationsWithSlug } from '@shared/models/organization/newOrganizationsWithSlug';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { regexs } from '@shared/constants/regexs';
import { RegOrganizationDto } from '../DTO/regOrganizationDto';
import { NewUserDto } from '../DTO/newUserDto';
import { uniqueSlugValidator } from '@shared/validators/unique-slug.validator';
import { uniqueSlugValidatorInRegistration } from '@shared/validators/unique-slug-in-registration.validator';
import { OrganizationService } from '@core/services/organization.service';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent extends BaseComponent implements OnInit {
    formGroup: FormGroup;
    user = {} as User;
    organization = {} as NewOrganizationsWithSlug;
    organizationSlug: string;

    password: string;
    confirmPassword: string;

    isNotFinishedRegistration = false;

    constructor(
        private authService: AuthenticationService,
        private toastService: ToastNotificationService,
        private organizationService: OrganizationService
    ) {
        super();
    }

    ngOnInit(): void {
        const user = this.authService.getUser();
        this.isNotFinishedRegistration = Boolean(user) && !user.registeredAt;
        if (this.isNotFinishedRegistration) {
            this.user = user;
        }

        this.formGroup = new FormGroup({
            firstName: new FormControl(
                { value: '', disabled: this.isNotFinishedRegistration },
                [
                    Validators.required,
                    Validators.minLength(2),
                    Validators.maxLength(30),
                    Validators.pattern(regexs.firstName)
                ]
            ),
            lastName: new FormControl(
                { value: '', disabled: this.isNotFinishedRegistration },
                [
                    Validators.minLength(2),
                    Validators.maxLength(30),
                    Validators.pattern(regexs.lastName)
                ]
            ),
            email: new FormControl(
                { value: '', disabled: this.isNotFinishedRegistration },
                [
                    Validators.required,
                    Validators.minLength(6),
                    Validators.pattern(regexs.email)
                ]
            ),
            organizationName: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.organizationName),
                ]
            ),
            organizationSlug: new FormControl(
                '', {
                    validators: [
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(50),
                        Validators.pattern(regexs.organizationSlag),
                    ],
                    asyncValidators: [
                        uniqueSlugValidatorInRegistration(this.organization, this.organizationService)
                    ]
                }

                // validators: [
                //     Validators.required,
                //     Validators.minLength(3),
                //     Validators.maxLength(50),
                //     Validators.pattern(regexs.organizationSlag),
                // ],
                // asyncValidators: [
                //     uniqueSlugValidator(this.organization, this.organizationService)
                // ]
            ),
            password: new FormControl(
                { value: '', disabled: this.isNotFinishedRegistration },
            ),
            confirmPassword: new FormControl(
                { value: '', disabled: this.isNotFinishedRegistration }
            ),
        });

        this.formGroup.controls.confirmPassword.setValidators([
            this.equals(this.formGroup.controls.password),
            Validators.required
        ]);
        this.formGroup.controls.password.setValidators([
            Validators.required,
            Validators.minLength(8),
            Validators.maxLength(30),
            Validators.pattern(regexs.password),
            this.validateAnother(this.formGroup.controls.confirmPassword)
        ]);
    }

    validateAnother = (another: AbstractControl) => () => {
        another.updateValueAndValidity();
        return null;
    };

    equals = (passwordControl: AbstractControl) => (control: AbstractControl) => {
        if (control.value !== passwordControl.value) {
            return { notEqual: true };
        }
        return null;
    };

    onSubmit() {
        const organizationDto: RegOrganizationDto = {
            organizationSlug: this.organizationSlug,
            name: this.organization.name,
            openMembership: true, //TEMP
            defaultRoleId: 1, //TEMP
            avatarUrl: null //TEMP
        } as RegOrganizationDto;

        if (!this.isNotFinishedRegistration) {
            const userDto = {
                ...this.user,
            } as NewUserDto;

            this.authService.signOnWithEmailAndPassword({ organization: organizationDto, user: userDto }, this.password, ['home'])
                .subscribe(() => { },
                    error => {
                        this.toastService.error(`${error}`, 'Error');
                    });
        } else {
            this.authService.finishPartialRegistration({ organization: organizationDto, userId: this.user.id }, ['home'])
                .subscribe(() => { },
                    error => {
                        this.toastService.error(`${error}`, 'Error');
                    });
        }
    }
}
