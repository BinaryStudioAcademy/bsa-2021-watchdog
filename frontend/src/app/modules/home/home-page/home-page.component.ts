import { Component, OnDestroy, OnInit } from '@angular/core';
import { BroadcastHubService } from '@core/hubs/broadcast-hub.service';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { DashboardService } from '@core/services/dashboard.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Subscription } from 'rxjs';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { User } from '@core/models/user';
import { BaseComponent } from '@core/components/base/base.component';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-home',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.sass']
})
export class HomeComponent extends BaseComponent implements OnInit, OnDestroy {
    dashboards: Dashboard[];
    dashboardsShown: boolean = false;
    displayModal: boolean = false;
    authorizedUser: User;

    constructor(
        private broadcastHub: BroadcastHubService,
        public dashboardService: DashboardService,
        private updateDataService: ShareDataService<Dashboard>,
        private deleteDataService: ShareDataService<number>,
        private toastNotificationService: ToastNotificationService
    ) {
        super();
    }

    async ngOnInit() {
        this.authorizedUser = { ...this.authorizedUser, firstName: 'Andriy' };

        this.getAllDashboards();

        await this.broadcastHub.start();
        this.broadcastHub.listenMessages((msg) => {
            console.log(`The next broadcast message was received: ${msg}`);
        });
    }

    addDashboard(newDashboard: NewDashboard) {
        this.displayModal = false;
        this.dashboardService.addDashboard(newDashboard)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.getAllDashboards();
                this.toastNotificationService.success('Dashboard has been added');
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
            });
    }

    async getAllDashboards() {
        this.dashboardService.getAll()
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.dashboards = resp.body;
                this.updateDataService.currentMessage
                    .pipe(this.untilThis)
                    .subscribe(dashboard => {
                        const key = this.dashboards.findIndex(el => el.id === dashboard.id);
                        this.dashboards[key] = dashboard;
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
