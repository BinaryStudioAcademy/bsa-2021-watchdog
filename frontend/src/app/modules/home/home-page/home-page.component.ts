import { IssuesHubService } from '@core/hubs/issues-hub.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BroadcastHubService } from '@core/hubs/broadcast-hub.service';
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

@Component({
    selector: 'app-home',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.sass']
})
export class HomeComponent extends BaseComponent implements OnInit, OnDestroy {
    dashboards: Dashboard[];
    userItems: MenuItem[];
    dashboardsShown: boolean = false;
    displayModal: boolean = false;
    collapsed: boolean = false;
    user: User;
    organization: Organization;

    constructor(
        private broadcastHub: BroadcastHubService,
        private issuesHub: IssuesHubService,
        public dashboardService: DashboardService,
        private updateDataService: ShareDataService<Dashboard>,
        private deleteDataService: ShareDataService<number>,
        private authService: AuthenticationService,
        private toastNotificationService: ToastNotificationService,
        private router: Router
    ) {
        super();
        this.user = authService.getUser();
        this.userItems = [
            { label: 'My profile', routerLink: 'users' },
            { label: 'Logout', routerLink: '../landing', command: () => this.authService.logout() }
        ];
    }

    ngOnInit() {
        this.user = this.authService.getUser();

        this.authService.getOrganization()
            .subscribe(organization => {
                this.organization = organization;
                this.getAllDashboards();
            });
        this.runHubs();
    }

    runHubs() {
        this.runBroadcastHub();
        this.runIssuesHub();
    }

    runBroadcastHub() {
        this.broadcastHub.start()
            .then(() => this.broadcastHub.listenMessages(msg =>
                this.toastNotificationService.info(`The next broadcast message was received: ${msg}`)))
            .catch(() => this.toastNotificationService.error('BroadcastHub failed to start.'));
    }

    runIssuesHub() {
        this.issuesHub.start()
            .then(() => {
                this.issuesHub.listenMessages(issue => {
                    this.toastNotificationService.info(`Received issue: ${issue.issueDetails.errorMessage}`);
                });
            })
            .catch(() => this.toastNotificationService.error('Issues Hub failed to start.'));
    }

    addDashboard(newDashboard: NewDashboard) {
        this.displayModal = false;
        this.dashboardService.addDashboard(newDashboard)
            .pipe(this.untilThis)
            .subscribe(dashboard => {
                this.getAllDashboards();
                this.toastNotificationService.success('Dashboard has been added');
                this.router.navigate([`/home/dashboard/${dashboard.id}`]);
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
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
                        this.toastNotificationService.error(`${error}`, 'Error', 2000);
                    });
            });
    }

    ngOnDestroy() {
        this.broadcastHub.stop();
        super.ngOnDestroy();
    }
}
