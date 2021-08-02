import { Component, OnInit } from '@angular/core';
import { Organization } from '@core/models/organization';
import { BaseComponent } from '@core/components/base/base.component';
import { MenuItem } from 'primeng/api';

@Component({
    selector: 'app-organization-menu',
    templateUrl: './organization-menu.component.html',
    styleUrls: ['./organization-menu.style.sass'],
})
export class OrganizationMenuComponent implements OnInit {
    organization: Organization;
    menuItems: MenuItem[];

    ngOnInit(): void {
        //getting organization, maybe from route... or inputed from parent

        this.menuItems = [
            { label: 'Organization settings', routerLink: './organization/settings' },
            { label: 'Teams', routerLink: './organization/teams/' },
            { label: 'Members', routerLink: './organization/members/' }
        ];
    }
}
