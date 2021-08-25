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

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.sass']
})
export class RegistrationFormComponent extends BaseComponent implements OnInit {
    personalDetail: FormGroup;
    ogranizationDetail: FormGroup;
    personal_step = false;
    organization_step = false;
    step = 1;


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
        if (this.step == 1) {
            this.personal_step = true;
            if (this.personalDetail.invalid) { return }
                this.step++;
        }
    }

    previous() {
        this.step--;
        if (this.step == 1) {
            this.personal_step = false;
        }
        if (this.step == 2) {
            this.organization_step = false
        }
    }

    submit() {
        if(this.step == 2) {
            this.organization_step = true;
            this.onSubmit();
            if (this.ogranizationDetail.invalid) { return; }
        }
    }

    onSubmit() {
        const organizationDto: RegOrganizationDto = {
            organizationSlug: this.organizationSlug,
            name: this.organization.name,
        } as RegOrganizationDto;
        if (!this.isNotFinishedRegistration) {
            const userDto = {
                ...this.user,
            } as NewUserDto;

            this.authService.signOnWithEmailAndPassword({ organization: organizationDto, user: userDto }, this.password, ['home'])
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

    get personalInfo() { return this.personalDetail.controls; }
    get organizationInfo() { return this.ogranizationDetail.controls; }
}
