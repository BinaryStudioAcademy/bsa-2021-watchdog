import { Component, OnInit } from '@angular/core';
import { User } from '@shared/models/user/user';
import { AuthenticationService } from '@core/services/authentication.service';
import { BaseComponent } from '@core/components/base/base.component';
import { NewOrganizationsWithSlug } from '@shared/models/organization/new-organizations-with-slug';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { regexs } from '@shared/constants/regexs';
import { RegOrganizationDto } from '../DTO/reg-organization-dto';
import { NewUserDto } from '../DTO/new-user-dto';
import { OrganizationService } from '@core/services/organization.service';
import { uniqueSlugValidator } from '@shared/validators/unique-slug.validator';
import { existOrganization } from '@shared/validators/exist-organization.validator';
import { RegistrationSteps } from './registration-steps';
import { RegistrationTabs } from './registration-tabs';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent extends BaseComponent implements OnInit {
    personalDetail: FormGroup;
    ogranizationDetail: FormGroup;
    ogranizationJoin: FormGroup;

    personalStep = false;
    organizationStep = false;

    stepRegistration = RegistrationSteps;
    step = this.stepRegistration.First;

    organizationSlugJoins: string;
    tabRegistration = RegistrationTabs;
    indexOfSelectedTab = this.tabRegistration.CreateOrganization;

    user = {} as User;
    organization = {} as NewOrganizationsWithSlug;
    organizationSlugs: string;

    passwords: string;
    confirmPasswords: string;

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

        this.personalDetail = new FormGroup({
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
            password: new FormControl(
                { value: '', disabled: this.isNotFinishedRegistration },
            ),
            confirmPassword: new FormControl(
                { value: '', disabled: this.isNotFinishedRegistration }
            ),
        });

        this.personalDetail.controls.confirmPassword.setValidators([
            this.equals(this.personalDetail.controls.password),
            Validators.required
        ]);
        this.personalDetail.controls.password.setValidators([
            Validators.required,
            Validators.minLength(8),
            Validators.maxLength(30),
            Validators.pattern(regexs.password),
            this.validateAnother(this.personalDetail.controls.confirmPassword)
        ]);

        this.ogranizationDetail = new FormGroup({
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
                '',
                {
                    validators: [
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(50),
                        Validators.pattern(regexs.organizationSlag),
                    ],
                    asyncValidators: [
                        uniqueSlugValidator(this.organizationService)
                    ]
                }
            ),
        });

        this.ogranizationJoin = new FormGroup({
            organizationSlugJoin: new FormControl(
                '',
                {
                    validators: [
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(50),
                        Validators.pattern(regexs.organizationSlag),
                    ],
                    asyncValidators: [
                        existOrganization(this.organizationService)
                    ]
                }
            ),
        });
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

    next() {
        if (this.step === this.stepRegistration.First) {
            this.personalStep = true;
            if (this.personalDetail.invalid) { return; }
            this.step += 1;
        }
    }

    previous() {
        this.step -= 1;
        if (this.step === this.stepRegistration.First) {
            this.personalStep = false;
        }
        if (this.step === this.stepRegistration.Second) {
            this.organizationStep = false;
        }
    }

    submit() {
        if (this.step === this.stepRegistration.Second) {
            this.organizationStep = true;
            if (this.indexOfSelectedTab === this.tabRegistration.CreateOrganization) {
                this.onSubmit();
            }
            if (this.indexOfSelectedTab === this.tabRegistration.JoinToOrganization) {
                this.onSumbitWithJoin();
            }
        }
    }

    onSubmit() {
        const organizationDto: RegOrganizationDto = {
            organizationSlug: this.organizationSlugs,
            name: this.organization.name,
        } as RegOrganizationDto;
        if (!this.isNotFinishedRegistration) {
            const userDto = {
                ...this.user,
            } as NewUserDto;

            this.authService.signOnWithEmailAndPassword({ organization: organizationDto, user: userDto }, this.passwords, ['home'])
                .subscribe(() => { },
                    error => {
                        this.toastService.error(error);
                    });
        } else {
            this.authService.finishPartialRegistration({ organization: organizationDto, userId: this.user.id }, ['home'])
                .subscribe(() => { },
                    error => {
                        this.toastService.error(error);
                    });
        }
    }

    onSumbitWithJoin() {
        if (!this.isNotFinishedRegistration) {
            const userDto = {
                ...this.user,
            } as NewUserDto;
            this.authService.singOnWithEmailAndPasswordWithJoin({ organizationSlug: this.organizationSlugJoins, user: userDto },
                this.passwords, ['home'])
                .subscribe(() => { },
                    error => {
                        this.toastService.error(error);
                    });
        } else {
            this.authService.finishPartialRegistrationWithJoin({ organizationSlug: this.organizationSlugJoins, userId: this.user.id },
                ['home'])
                .subscribe(() => { },
                    error => {
                        this.toastService.error(error);
                    });
        }
    }

    handleChange(e) {
        this.indexOfSelectedTab = e.index;
    }

    get personalInfo() { return this.personalDetail.controls; }
    get organizationInfo() { return this.ogranizationDetail.controls; }
    get firstName() { return this.personalDetail.controls.firstName; }
    get lastName() { return this.personalDetail.controls.lastName; }
    get email() { return this.personalDetail.controls.email; }
    get password() { return this.personalDetail.controls.password; }
    get confirmPassword() { return this.personalDetail.controls.confirmPassword; }
    get organizationName() { return this.personalDetail.controls.organizationName; }
    get organizationSlug() { return this.personalDetail.controls.organizationSlug; }
    get organizationSlugJoin() { return this.personalDetail.controls.organizationSlugJoin; }

}
