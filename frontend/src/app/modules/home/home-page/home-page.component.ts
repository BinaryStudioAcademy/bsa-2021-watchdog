import { Component, OnDestroy, OnInit } from '@angular/core';
import { BroadcastHubService } from '@core/hubs/broadcast-hub.service';
import {Dashboard} from "@shared/models/Dashboard"
import {DashboardService} from "@core/services/dashboard.service";

@Component({
    selector: 'app-home',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.sass']
})
export class HomeComponent implements OnInit, OnDestroy {
    dashboards: Dashboard[];
    dashboardsShown: boolean = false;
    displayModal: boolean = false;

    constructor(private broadcastHub: BroadcastHubService,
                public dashboardService: DashboardService) { }

    async ngOnInit() {
        this.dashboards = this.dashboardService.getAll();

        await this.broadcastHub.start();
        this.broadcastHub.listenMessages((msg) => {
            console.log(`The next broadcast message was received: ${msg}`)
        });
    }

    ngOnDestroy() {
        this.broadcastHub.stop();
    }

    addDashboard(dashboard: Dashboard){
        this.displayModal = false;
        this.dashboardService.addDashboard(dashboard);
    }
}
