import { BaseComponent } from '@core/components/base/base.component';
import { OrganizationService } from '@core/services/organization.service';
import { FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Organization } from '@shared/models/organization/organization';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { regexs } from '@shared/constants/regexs';
import { uniqueSlugValidator } from '@shared/validators/unique-slug.validator';
import { of } from 'rxjs';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { CroppedEvent } from 'ngx-photo-editor';
import { AvatarDto } from '@shared/models/avatar/avatarDto';
import { FileUpload } from 'primeng/fileupload';

@Component({
    selector: 'app-general-settings',
    templateUrl: './general-settings.component.html',
    styleUrls: ['../organization-settings.style.sass']
})
export class GeneralSettingsComponent extends BaseComponent implements OnInit {
    @Input() organization: Organization;
    @Input() parentForm: FormGroup;

    loading: boolean = false;
    errorUpdateMessage: string;
    @ViewChild(FileUpload) fileUpload: FileUpload;
    imageChangedEvent: { target: { files: File[] } };
    constructor(
        private organizationService: OrganizationService,
        private toastNotificationService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.connectForm();
    }

    connectForm(): void {
        this.parentForm.addControl('name', new FormControl(this.organization.name, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50),
            Validators.pattern(regexs.organizationName),
        ]));
        this.parentForm.addControl('organizationSlug', new FormControl(this.organization.organizationSlug, {
            validators: [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(50),
                Validators.pattern(regexs.organizationSlag),
            ],
            asyncValidators: [
                this.slagValidator,
            ]
        }));
    }

    slagValidator = (ctrl: AbstractControl) => {
        if (this.organization.organizationSlug === ctrl.value) {
            return of(null);
        }
        return uniqueSlugValidator(this.organizationService)(ctrl);
    };

    onError(e) {
        this.toastNotificationService.error(e.error);
        this.fileUpload.clear();
    }

    upload(e: { files: File[] }) {
        this.imageChangedEvent = { target: { files: e.files } };
        this.fileUpload.clear();
    }

    imageCropped(event: CroppedEvent) {
        const avatar: AvatarDto = { id: this.organization.id, base64: event.base64 };
        this.organization.avatarUrl = event.base64;
        this.organizationService.updateAvatar(avatar)
            .subscribe(() => { },
                error => {
                    this.toastNotificationService.error(error);
                });
    }

    get name() { return this.parentForm.controls.name; }

    get organizationSlug() { return this.parentForm.controls.organizationSlug; }
}
