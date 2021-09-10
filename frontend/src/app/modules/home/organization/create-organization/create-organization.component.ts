import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { NewOrganization } from '@shared/models/organization/new-organization';
import { OrganizationService } from '@core/services/organization.service';
import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { regexs } from '@shared/constants/regexs';
import { uniqueSlugValidator } from '@shared/validators/unique-slug.validator';
import { User } from '@shared/models/user/user';
import { Organization } from '@shared/models/organization/organization';
import { existOrganization } from '@shared/validators/exist-organization.validator';
import { RegistrationTabs } from '@modules/registration/registration-form/registration-tabs';
import { RegistrationService } from '@core/services/registration.service';
import { JoinToOrganization } from '@shared/models/member/join-to-organization';

@Component({
    selector: 'app-create-organization[hasOrganization]',
    templateUrl: './create-organization.component.html',
    styleUrls: ['./create-organization.component.sass']
})
export class CreateOrganizationComponent extends BaseComponent implements OnInit {
    formGroup: FormGroup;
    formGroupJoin: FormGroup;
    user: User;
    indexOfSelectedTab = RegistrationTabs.CreateOrganization;
    private displayDialog: boolean;
    get display(): boolean {
        return this.displayDialog;
    }
    @Input() set display(value: boolean) {
        this.displayDialog = value;
        this.formGroup?.reset();
        this.displayChange.emit(value);
    }

    @Input() hasOrganization: boolean;
    @Output() displayChange = new EventEmitter<boolean>();
    @Output() organizationCreate = new EventEmitter<Organization>();

    constructor(
        private organizationService: OrganizationService,
        private authService: AuthenticationService,
        private toastNotification: ToastNotificationService,
        private registrationService: RegistrationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();

        this.formGroupJoin = new FormGroup({
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

        this.formGroup = new FormGroup({
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
            )
        });
    }

    get slug() { return this.formGroup.controls.organizationSlug; }
    get slugForJoin() { return this.formGroupJoin.controls.organizationSlugJoin; }
    get name() { return this.formGroup.controls.organizationName; }

    submit() {
        if (this.indexOfSelectedTab === RegistrationTabs.CreateOrganization) {
            this.createOrganization();
        }
        if (this.indexOfSelectedTab === RegistrationTabs.JoinToOrganization) {
            this.joinToOrganization();
        }
    }

    joinToOrganization() {
        const userForJoin: JoinToOrganization = {
            id: this.user.id,
            organizationSlug: this.slugForJoin.value
        };
        this.registrationService.joinToOrganization(userForJoin)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.display = false;
                this.organizationService.getOrganizationBySlug(this.slugForJoin.value)
                    .pipe(this.untilThis)
                    .subscribe(organization => {
                        if (organization.openMembership) {
                            this.organizationCreate.emit(organization);
                            this.toastNotification.success('Successful join');
                        } else {
                            this.toastNotification.info('You must be accepted to organization');
                        }
                    });
            }, error => {
                this.toastNotification.error(error);
            });
    }

    createOrganization() {
        const newOrganization: NewOrganization = {
            name: this.formGroup.controls.organizationName.value,
            organizationSlug: this.formGroup.controls.organizationSlug.value,
            createdBy: this.user.id
        };
        this.organizationService.createOrganization(newOrganization)
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organizationCreate.emit(organization);
                this.display = false;
            }, error => {
                this.toastNotification.error(error);
            });
    }

    handleChange(e) {
        this.indexOfSelectedTab = e.index;
    }
}
