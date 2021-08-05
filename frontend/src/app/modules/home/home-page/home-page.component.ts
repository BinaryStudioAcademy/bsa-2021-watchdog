import { Component, OnDestroy, OnInit } from '@angular/core';
import { BroadcastHubService } from '@core/hubs/broadcast-hub.service';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { DashboardService } from '@core/services/dashboard.service';
import { DataService } from '@core/services/share-data.service';
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
    updateSubscription$: Subscription;
    deleteSubscription$: Subscription;
    dashboardsShown: boolean = false;
    displayModal: boolean = false;
    authorizedUser: User;

    constructor(
        private broadcastHub: BroadcastHubService,
        public dashboardService: DashboardService,
        private toastNotificationService: ToastNotificationService,
        private updateDataService: DataService<Dashboard>,
        private deleteDataService: DataService<number>
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
        newDashboard.createdBy = 1;
        newDashboard.organizationId = 1;
        this.dashboardService.addDashboard(newDashboard)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.getAllDashboards();
                this.toastNotificationService.success('Dashboard has been added');
            });
    }

    getAllDashboards() {
        this.dashboardService.getAll()
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.dashboards = resp.body;
                this.updateSubscription$ = this.updateDataService.currentMessage
                    .subscribe(dashboard => {
                        const key = this.dashboards.findIndex(el => el.id === dashboard.id);
                        this.dashboards[key] = dashboard;
                    });

                this.deleteSubscription$ = this.deleteDataService.currentMessage
                    .subscribe(id => {
                        this.dashboards = this.dashboards.filter(d => d.id !== id);
                    });
            });
    }

    ngOnDestroy() {
        this.broadcastHub.stop();
        this.updateSubscription$.unsubscribe();
        super.ngOnDestroy();
    }
}
