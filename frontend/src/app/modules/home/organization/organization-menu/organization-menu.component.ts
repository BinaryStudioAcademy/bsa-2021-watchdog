import { OrganizationService } from "@core/services/organization.service";
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Component, OnInit } from '@angular/core';
import { Organization } from '@shared/models/organization/organization';
import { BaseComponent } from '@core/components/base/base.component';
import { MenuItem } from 'primeng/api';
import { AuthenticationService } from '@core/services/authentication.service';
import { Router } from '@angular/router';
import { runInThisContext } from "vm";

@Component({
    selector: 'app-organization-menu',
    templateUrl: './organization-menu.component.html',
    styleUrls: ['./organization-menu.style.sass'],
})
export class OrganizationMenuComponent extends BaseComponent implements OnInit {
    isLoading: boolean = false;
    organization: Organization;
    menuItems: MenuItem[] = [];

    constructor(
        private dataService: ShareDataService<Organization>,
        private authSerice: AuthenticationService,
        private toastService: ToastNotificationService,
        private organizationService: OrganizationService,
        public router: Router,
    ) { super(); }

    ngOnInit(): void {
        this.isLoading = true;
        this.authSerice.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;
                this.checkUpdates();
                this.isLoading = false;
            }, error => { this.toastService.error(error); this.isLoading = false; });

        this.organizationService.getOrganizationsByUserId(this.authSerice.getUser().id)
            .pipe(this.untilThis)
            .subscribe(organizations => {
                this.menuItems = organizations.map(org => {
                    return { label: `${org.name}`, escape: true }
                });
            });
    }

    private checkUpdates() {
        this.dataService.currentMessage
            .pipe(this.untilThis)
            .subscribe(organization => {
                if (this.organization.id === organization.id) {
                    this.organization = organization;
                }
            });
    }
}
