import { Component, OnDestroy, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardService } from '@core/services/dashboard.service';
import { DataService } from '@core/services/share-data.service';
import { Subscription } from 'rxjs';
import { BaseComponent } from '@core/components/base/base.component';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { ToastNotificationService } from '@core/services/toast-notification.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent extends BaseComponent implements OnInit, OnDestroy {
    isEditing: boolean;
    showTileMenu: boolean;
    dashboard: Dashboard;
    updateSubscription$: Subscription;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private dashboardService: DashboardService,
        private toastNotificationService: ToastNotificationService,
        private updateDataService: DataService<Dashboard>,
        private deleteDataService: DataService<number>
    ) {
        super();
    }

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            const { id } = params;
            this.showTileMenu = false;
            this.dashboardService.get(id)
                .pipe(this.untilThis)
                .subscribe(resp => {
                    this.dashboard = resp.body;
                    this.updateSubscription$ = this.updateDataService.currentMessage
                        .subscribe((dashboard) => {
                            this.dashboard = dashboard;
                        });
                });
        });
    }

    updateDashboard(dashboard: UpdateDashboard) {
        this.isEditing = false;
        this.dashboardService.updateDashboard(dashboard)
            .pipe(this.untilThis)
            .subscribe(resp => {
                this.dashboard = resp.body;
                this.updateDataService.changeMessage(this.dashboard);
                this.toastNotificationService.success('Dashboard has been updateded');
            });
    }

    deleteDashboard() {
        this.dashboardService.deleteDashboard(this.dashboard.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.router.navigate(['/home/projects']).then(r => r);
                this.toastNotificationService.success('Dashboard has been deleted');
            });
        this.deleteDataService.changeMessage(this.dashboard.id);
    }

    toggleTileMenu(): void {
        this.showTileMenu = !this.showTileMenu;
    }

    ngOnDestroy(): void {
        this.updateSubscription$.unsubscribe();
        super.ngOnDestroy();
    }

    tileMenuClosed() {
        this.showTileMenu = false;
    }
}
