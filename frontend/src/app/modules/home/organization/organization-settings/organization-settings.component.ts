import { BaseComponent } from "@core/components/base/base.component";
import { OrganizationService } from "@core/services/organization.service";
import { Organization } from '@core/models/organization';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-organization-settings',
    templateUrl: './organization-settings.component.html',
    styleUrls: ['./organization-settings.style.sass']
})
export class OrganizationSettingsComponent extends BaseComponent implements OnInit {
    organization: Organization;
    constructor(private organizationService: OrganizationService) { super(); }

    ngOnInit() {

        this.organizationService.getOrganization(3)
            .pipe(this.untilThis)
            .subscribe(o => this.organization = o);
    }
}
