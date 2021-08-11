import { FormGroup } from "@angular/forms";
import { Subject } from "rxjs";
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { OrganizationService } from '@core/services/organization.service';
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
        private organizationService: OrganizationService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.isLoading = true;
        this.organizationService.getCurrentOrganization()
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

    }
}
