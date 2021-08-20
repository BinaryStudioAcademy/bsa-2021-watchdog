import { OrganizationService } from '@core/services/organization.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { OrganizationSettings } from '@shared/models/organization/organization-settings';
import { FormGroup } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { Organization } from '@shared/models/organization/organization';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { SpinnerService } from '@core/services/spinner.service';

@Component({
    selector: 'app-organization-settings',
    templateUrl: './organization-settings.component.html',
    styleUrls: ['./organization-settings.style.sass']
})
export class OrganizationSettingsComponent extends BaseComponent implements OnInit {
    organization: Organization;
    parentForm: FormGroup = new FormGroup({});

    @ViewChild('saveBut') saveButton: ElementRef<HTMLButtonElement>;

    constructor(
        private authService: AuthenticationService,
        private toastService: ToastNotificationService,
        private organizationService: OrganizationService,
        private spinnerService: SpinnerService
    ) { super(); }

    ngOnInit() {
        this.spinnerService.show(true);
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(
                organization => {
                    this.organization = organization;
                    this.spinnerService.hide();
                },
                error => {
                    this.toastService.error(error);
                    this.spinnerService.hide();
                }
            );

        this.parentForm.statusChanges.subscribe(() => { this.checkSaveStatus(); });
    }

    checkSaveStatus() {
        if (this.parentForm.untouched || this.parentForm.pending || this.parentForm.invalid) {
            this.setButtonStateDisabled(true);
        }
        if (this.parentForm.valid && (this.parentForm.touched || this.parentForm.dirty)) {
            const unsavedChangesProps = Object.keys(this.parentForm.controls)
                .filter(key =>
                    this.parentForm.controls[key].value !== this.organization[key]);

            if (unsavedChangesProps.length > 0) this.setButtonStateDisabled(false);
            else this.setButtonStateDisabled(true);
        }
    }

    reset() {
        this.parentForm.reset(this.organization);
    }

    save() {
        this.spinnerService.show(true);
        const updateOrg: OrganizationSettings = { ...this.parentForm.value };
        this.organizationService.updateSettings(this.organization.id, updateOrg)
            .pipe(this.untilThis).subscribe(updatedOrg => {
                Object.assign(this.organization, updatedOrg);
                this.spinnerService.hide();
                this.saveButton.nativeElement.disabled = true;
                this.toastService.success('Organization was updated!');
            }, error => {
                this.spinnerService.hide();
                this.toastService.error(error);
            });
    }

    setButtonStateDisabled(state: boolean) {
        if (this.saveButton) this.saveButton.nativeElement.disabled = state;
    }
}
