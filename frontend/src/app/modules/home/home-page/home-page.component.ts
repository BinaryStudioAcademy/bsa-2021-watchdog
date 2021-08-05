import { Component, OnDestroy, OnInit } from '@angular/core';
import { BroadcastHubService } from '@core/hubs/broadcast-hub.service';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { DashboardService } from '@core/services/dashboard.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Subscription } from 'rxjs';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { User } from '@core/models/user';

@Component({
    selector: 'app-home',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.sass']
})
export class HomeComponent implements OnInit, OnDestroy {
    dashboards: Dashboard[];
    updateSubscription$: Subscription;
    deleteSubscription$: Subscription;
    dashboardsShown: boolean = false;
    displayModal: boolean = false;
    authorizedUser: User;

    constructor(
        private broadcastHub: BroadcastHubService,
        public dashboardService: DashboardService,
        private updateDataService: ShareDataService<Dashboard>,
        private deleteDataService: ShareDataService<number>
    ) { }

    async ngOnInit() {
        this.authorizedUser = { ...this.authorizedUser, firstName: 'Andriy' };

        this.dashboards = this.dashboardService.getAll();

        this.updateSubscription$ = this.updateDataService.currentMessage
            .subscribe(dashboard => {
                const key = this.dashboards.findIndex(el => el.id === dashboard.id);
                this.dashboards[key] = dashboard;
            });

        this.deleteSubscription$ = this.deleteDataService.currentMessage
            .subscribe(id => {
                this.dashboards = this.dashboards.filter(d => d.id !== id);
            });

        await this.broadcastHub.start();
        this.broadcastHub.listenMessages((msg) => {
            console.log(`The next broadcast message was received: ${msg}`);
        });
    }

    addDashboard(newDashboard: NewDashboard) {
        this.displayModal = false;
        this.dashboardService.addDashboard(newDashboard);
    }

    ngOnDestroy() {
        this.broadcastHub.stop();
        this.updateSubscription$.unsubscribe();
    }
}
