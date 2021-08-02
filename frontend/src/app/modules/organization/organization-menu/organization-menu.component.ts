import { OrganizationService } from "@core/services/organization.service";
import { Component, OnInit } from '@angular/core';
import { Organization } from '@core/models/organization';
import { BaseComponent } from '@core/components/base/base.component';
import { MenuItem } from 'primeng/api';
import { User } from "@core/models/user";

@Component({
    selector: 'app-organization-menu',
    templateUrl: './organization-menu.component.html',
    styleUrls: ['./organization-menu.style.sass'],
})
export class OrganizationMenuComponent extends BaseComponent implements OnInit {
    organization: Organization;
    menuItems: MenuItem[];
    currentUser: User;

    constructor(private organizationService: OrganizationService) { super(); }

    ngOnInit(): void {
        this.organizationService.getOrganization(3)
            .pipe(this.untilThis)
            .subscribe(o => { this.organization = o; });

        this.menuItems = [
            { label: 'Organization settings', routerLink: './organization/settings' },
            { label: 'Teams', routerLink: './organization/teams/' },
            { label: 'Members', routerLink: './organization/members/' }
        ];
    }
}