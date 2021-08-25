import { OrganizationService } from '@core/services/organization.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Component, Input, OnInit } from '@angular/core';
import { Organization } from '@shared/models/organization/organization';
import { BaseComponent } from '@core/components/base/base.component';
import { MenuItem } from 'primeng/api';
import { AuthenticationService } from '@core/services/authentication.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-organization-menu',
    templateUrl: './organization-menu.component.html',
    styleUrls: ['./organization-menu.style.sass'],
})
export class OrganizationMenuComponent extends BaseComponent implements OnInit {
    isLoading: boolean = false;
    organization: Organization;
    organizations: Organization[];
    menuItems: MenuItem[] = [];
    display: boolean = false;
    @Input() collapsed: boolean = false;

    constructor(
        private dataService: ShareDataService<Organization>,
        private authService: AuthenticationService,
        private toastService: ToastNotificationService,
        private organizationService: OrganizationService,
        public router: Router,
    ) { super(); }

    ngOnInit(): void {
        this.isLoading = true;
        this.organizationService.getOrganizationsByUserId(this.authService.getUser().id)
            .pipe(this.untilThis)
            .subscribe(organizations => {
                this.organizations = organizations;
                this.authService.getOrganization()
                    .pipe(this.untilThis)
                    .subscribe(organization => {
                        this.organization = organization;
                        this.checkUpdates();
                        this.isLoading = false;
                    });
            }, error => {
                this.toastService.error(error);
                this.isLoading = false;
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

    async changeOrganization(organization: Organization) {
        this.authService.setOrganization(organization);
        const { url } = this.router;
        await this.router.navigateByUrl('/', { skipLocationChange: true });
        await this.router.navigateByUrl(url);
    }

    clickIcon(event: Event) {
        this.disableParentEvent(event);
    }

    disableParentEvent(event: Event) {
        event.stopPropagation();
    }

    async organizationCreated(organization: Organization) {
        this.organizations = this.organizations.concat(organization);
        await this.changeOrganization(organization);
        await this.router.navigateByUrl('home/organization/settings');
    }
}
