import { OrganizationService } from "@core/services/organization.service";
import { AuthenticationService } from "@core/services/authentication.service";
import { OrganizationSettings } from "@shared/models/organization/organization-settings";
import { FormGroup } from "@angular/forms";
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Organization } from '@shared/models/organization/organization';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
    selector: 'app-organization-settings',
    templateUrl: './organization-settings.component.html',
    styleUrls: ['./organization-settings.style.sass']
})
export class OrganizationSettingsComponent extends BaseComponent implements OnInit {
    isLoading: boolean = false;
    organization: Organization;
    parentForm: FormGroup = new FormGroup({});

    @ViewChild("saveBut") saveButton: ElementRef<HTMLButtonElement>;

    constructor(
        private authService: AuthenticationService,
        private toastService: ToastNotificationService,
        private organizationService: OrganizationService
    ) { super(); }

    ngOnInit() {
        this.isLoading = true;
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(
                organization => {
                    this.organization = organization;
                    this.isLoading = false;
                },
                error => {
                    this.toastService.error(error);
                    this.isLoading = false;
                }
            );

        this.parentForm.statusChanges.subscribe(() => { this.checkSaveStatus(); });
    }

    checkSaveStatus() {
        if (this.parentForm.untouched || this.parentForm.pending || this.parentForm.invalid) {
            this.saveButton.nativeElement.disabled = true;
        }
        if (this.parentForm.valid && (this.parentForm.touched || this.parentForm.dirty)) {
            const unsavedChangesProps = Object.keys(this.parentForm.controls)
                .filter(key =>
                    this.parentForm.controls[key].value !== this.organization[key]);

            if (unsavedChangesProps.length > 0) this.saveButton.nativeElement.disabled = false;
            else this.saveButton.nativeElement.disabled = true;
        }
    }

    reset() {
        this.parentForm.reset(this.organization);
    }

    save() {
        this.isLoading = true;
        const updateOrg: OrganizationSettings = { ...this.parentForm.value };
        this.organizationService.updateSettings(this.organization.id, updateOrg)
            .pipe(this.untilThis).subscribe(updatedOrg => {
                Object.assign(this.organization, updatedOrg);
                this.isLoading = false;
                this.saveButton.nativeElement.disabled = true;
                this.toastService.success("Organization was updated!");
            }, error => {
                this.isLoading = false;
                this.toastService.error(error);
            });
    }
}
