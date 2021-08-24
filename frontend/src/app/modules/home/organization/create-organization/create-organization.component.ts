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

@Component({
    selector: 'app-create-organization',
    templateUrl: './create-organization.component.html',
    styleUrls: ['./create-organization.component.sass']
})
export class CreateOrganizationComponent extends BaseComponent implements OnInit {
    formGroup: FormGroup;
    user: User;
    private displayDialog: boolean;
    get display(): boolean {
        return this.displayDialog;
    }
    @Input() set display(value: boolean) {
        this.displayDialog = value;
        this.formGroup?.reset();
        this.displayChange.emit(value);
    }
    @Output() displayChange = new EventEmitter<boolean>();
    @Output() organizationCreate = new EventEmitter<Organization>();

    constructor(
        private organizationService: OrganizationService,
        private authService: AuthenticationService,
        private toastNotification: ToastNotificationService
    ) {
        super();
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();

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
                        uniqueSlugValidator('', this.organizationService)
                    ]
                }
            )
        });
    }

    get slug() { return this.formGroup.controls.organizationSlug; }
    get name() { return this.formGroup.controls.organizationName; }

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
}
