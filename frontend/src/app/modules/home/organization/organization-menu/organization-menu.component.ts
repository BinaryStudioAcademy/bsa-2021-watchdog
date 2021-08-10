import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ShareDataService } from '@core/services/share-data.service';
import { OrganizationService } from '@core/services/organization.service';
import { Component, OnInit } from '@angular/core';
import { Organization } from '@shared/models/organization/organization';
import { BaseComponent } from '@core/components/base/base.component';
import { MenuItem } from 'primeng/api';
import { User } from '@shared/models/user/user';
import { AuthenticationService } from '@core/services/authentication.service';

@Component({
    selector: 'app-organization-menu',
    templateUrl: './organization-menu.component.html',
    styleUrls: ['./organization-menu.style.sass'],
})
export class OrganizationMenuComponent extends BaseComponent implements OnInit {
    organization: Organization;
    menuItems: MenuItem[];
    currentUser: User;

    constructor(
        private dataService: ShareDataService<Organization>,
        private authSerice: AuthenticationService,
        private toastService: ToastNotificationService
    ) { super(); }

    ngOnInit(): void {
        this.authSerice.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;
                this.checkUpdates();
            }, error => { this.toastService.error(error); });

        this.menuItems = [
            { label: 'Organization settings', routerLink: './organization/settings' },
            { label: 'Teams', routerLink: './teams/' },
            { label: 'Members', routerLink: './organization/members/' }
        ];
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
