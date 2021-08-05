import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { OrganizationService } from '@core/services/organization.service';
import { Organization } from '@shared/models/organization/organization';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-organization-settings',
    templateUrl: './organization-settings.component.html',
    styleUrls: ['./organization-settings.style.sass']
})
export class OrganizationSettingsComponent extends BaseComponent implements OnInit {
    organization: Organization;
    constructor(
        private organizationService: OrganizationService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit() {
        this.organizationService.getOrganization(1)
            .pipe(this.untilThis)
            .subscribe(
                organization => { this.organization = organization; },
                error => { this.toastService.error(error); }
            );
    }
}
