import { Component, OnDestroy, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/Dashboard';
import { ActivatedRoute } from '@angular/router';
import { DashboardService } from '@core/services/dashboard.service';
import { DataService } from '@core/services/share-data.service';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent implements OnInit, OnDestroy {
    isEditing: boolean;
    dashboard: Dashboard;
    subscription: Subscription;

    constructor(
        private route: ActivatedRoute,
        private dashboardService: DashboardService,
        private dataService: DataService
    ) { }

    ngOnInit(): void {
        this.subscription = this.dataService.currentMessage
            .subscribe((dashboard) => { this.dashboard = dashboard });

        this.route.params.subscribe(params => {
            const { id } = params;
            this.dashboard = this.dashboardService.get(id);
        });
    }

    updateDashboard(dashboard: Dashboard) {
        this.isEditing = false;
        this.dashboard = this.dashboardService.updateDashboard(dashboard);
        this.dataService.changeMessage(this.dashboard);
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}
