import { Component, OnDestroy, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/Dashboard';
import { ActivatedRoute, Router } from '@angular/router';
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
    showTileMenu: boolean;
    dashboard: Dashboard;
    updateSubscription$: Subscription;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private dashboardService: DashboardService,
        private updateDataService: DataService<Dashboard>,
        private deleteDataService: DataService<number>
    ) {
    }

    ngOnInit(): void {
        this.updateSubscription$ = this.updateDataService.currentMessage
            .subscribe((dashboard) => {
                this.dashboard = dashboard;
            });

        this.route.params.subscribe(params => {
            const { id } = params;
            this.showTileMenu = false;
            this.dashboard = this.dashboardService.get(id);
        });
    }

    updateDashboard(dashboard: Dashboard) {
        this.isEditing = false;
        this.dashboard = this.dashboardService.updateDashboard(dashboard);
        this.updateDataService.changeMessage(this.dashboard);
    }

    deleteDashboard() {
        if (this.dashboardService.deleteDashboard(this.dashboard.id)) {
            this.router.navigate(['/home/projects']).then(r => r);
        }
        this.deleteDataService.changeMessage(this.dashboard.id);
    }

    toggleTileMenu(): void {
        this.showTileMenu = !this.showTileMenu;
    }

    ngOnDestroy(): void {
        this.updateSubscription$.unsubscribe();
    }

    tileMenuClosed() {
        this.showTileMenu = false;
    }
}
