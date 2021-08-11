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
    save: Subject<void> = new Subject<void>();
    reset: Subject<void> = new Subject<void>();
    canSaveMembership: boolean = true;
    canSaveGeneral: boolean = true;



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
    }

    changeGeneralSaveState(state: boolean) {
        this.canSaveGeneral = state;

        if (this.canSaveMembership) {
            this.saveButton.nativeElement.disabled = false;
        }
        else {
            this.saveButton.nativeElement.disabled = true;
        }
    }

    changeMembershipSaveState(state: boolean) {
        this.canSaveMembership = state;

        if (this.canSaveGeneral) {
            this.saveButton.nativeElement.disabled = false;
        }
        else {
            this.saveButton.nativeElement.disabled = true;
        }
    }
}
