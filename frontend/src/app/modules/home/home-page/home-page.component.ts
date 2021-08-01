import { Component, OnChanges, OnDestroy, OnInit } from '@angular/core';
import { BroadcastHubService } from '@core/hubs/broadcast-hub.service';
import { Dashboard } from '@shared/models/dashboard/Dashboard';
import { DashboardService } from '@core/services/dashboard.service';
import { DataService } from '@core/services/share-data.service';
import { Subscription } from 'rxjs';
import { NewDashboard } from '@shared/models/dashboard/NewDashboard';

@Component({
    selector: 'app-home',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.sass']
})
export class HomeComponent implements OnInit, OnDestroy, OnChanges {
    dashboards: Dashboard[];
    subscription: Subscription;
    dashboardsShown: boolean = false;
    displayModal: boolean = false;

    constructor(
        private broadcastHub: BroadcastHubService,
        public dashboardService: DashboardService,
        private dataService: DataService
    ) { }

    async ngOnInit() {
        this.dashboards = this.dashboardService.getAll();

        this.subscription = this.dataService.currentMessage
            .subscribe(dashboard => {
                if (dashboard.id !== undefined) {
                    const key = this.dashboards.findIndex(el => el.id === dashboard.id);
                    this.dashboards[key] = dashboard;
                }
            });

        await this.broadcastHub.start();
        this.broadcastHub.listenMessages((msg) => {
            console.log(`The next broadcast message was received: ${msg}`);
        });
    }

    ngOnDestroy() {
        this.broadcastHub.stop();
        this.subscription.unsubscribe();
    }

    addDashboard(newDashboard: NewDashboard) {
        this.displayModal = false;
        this.dashboardService.addDashboard(newDashboard);
    }

    ngOnChanges(): void {
        this.dashboards = this.dashboardService.getAll();
    }
}
