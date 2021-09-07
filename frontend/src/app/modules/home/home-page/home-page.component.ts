import { IssuesHubService } from '@core/hubs/issues-hub.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { DashboardService } from '@core/services/dashboard.service';
import { ShareDataService } from '@core/services/share-data.service';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { User } from '@shared/models/user/user';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { MenuItem } from 'primeng/api/menuitem';
import { Organization } from '@shared/models/organization/organization';
import { Router } from '@angular/router';
import { SpinnerService } from '@core/services/spinner.service';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AddDashboardComponent } from '../modals/dashboard/add-dashboard.component';

@Component({
    selector: 'app-home',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.sass']
})
export class HomeComponent extends BaseComponent implements OnInit, OnDestroy {
    dashboards: Dashboard[];
    userItems: MenuItem[];
    display: boolean = false;
    dashboardsShown: boolean = false;
    displayModal: boolean = false;
    collapsed: boolean = false;
    user: User;
    organization: Organization;
    createDashboardDialog: DynamicDialogRef;

    constructor(
        private issuesHub: IssuesHubService,
        public dashboardService: DashboardService,
        private updateDataService: ShareDataService<Dashboard>,
        private deleteDataService: ShareDataService<number>,
        private authService: AuthenticationService,
        private dialogService: DialogService,
        private toastNotificationService: ToastNotificationService,
        private router: Router,
        private spinner: SpinnerService
    ) {
        super();
        this.user = authService.getUser();
        this.userItems = [
            { label: 'My profile', routerLink: 'users' },
            { label: 'Logout', routerLink: '../landing', command: () => this.authService.logout() }
        ];
    }

    async ngOnInit() {
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .subscribe(async organization => {
                this.organization = organization;
                this.getAllDashboards();
                await this.runHubs();
            }, () => {
                this.spinner.hide();
                this.display = true;
            });
    }

    async runHubs() {
        await this.runIssuesHub();
    }

    async runIssuesHub() {
        try {
            await this.issuesHub.start();
            this.issuesHub.listenMessages(issue => {
                this.toastNotificationService.info(`Received issue: ${issue.issueDetails.errorMessage}`);
            });
        } catch {
            this.toastNotificationService.error('Issues Hub failed to start.');
        }
    }

    openAddDashboarDialog() {
        this.createDashboardDialog = this.dialogService.open(AddDashboardComponent, {
            header: 'Add dashboard',
            width: '400px',
            showHeader: true,
            baseZIndex: 10000,
        });

        this.createDashboardDialog.onClose
            .pipe(this.untilThis)
            .subscribe((newDashboard: NewDashboard) => {
                if (newDashboard) {
                    this.dashboardService.addDashboard(newDashboard)
                        .pipe(this.untilThis)
                        .subscribe(async dashboard => {
                            await this.getAllDashboards();
                            this.toastNotificationService.success('Dashboard has been added');
                            await this.router.navigate([`/home/dashboard/${dashboard.id}`]);
                        }, error => {
                            this.toastNotificationService.error(error);
                        });
                }
            });
    }

    async getAllDashboards() {
        this.dashboardService.getAllByOrganization(this.organization.id)
            .pipe(this.untilThis)
            .subscribe(dashboard => {
                this.dashboards = dashboard;
                this.updateDataService.currentMessage
                    .pipe(this.untilThis)
                    .subscribe(d => {
                        const key = this.dashboards.findIndex(el => el.id === d.id);
                        this.dashboards[key] = d;
                    });

                this.deleteDataService.currentMessage
                    .pipe(this.untilThis)
                    .subscribe(id => {
                        this.dashboards = this.dashboards.filter(d => d.id !== id);
                    }, error => {
                        this.toastNotificationService.error(error);
                    });
            });
    }

    async changeOrganization(organization: Organization) {
        this.authService.setOrganization(organization);
        await this.router.navigateByUrl('home/organization/settings');
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
