import { Component, OnDestroy, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardService } from '@core/services/dashboard.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Subscription } from 'rxjs';
import { BaseComponent } from '@core/components/base/base.component';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { SpinnerService } from '@core/services/spinner.service';
import { ConfirmOptions } from '@shared/models/confirm-window/confirm-options';
import { ConfirmWindowService } from '@core/services/confirm-window.service';

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
        private updateDataService: ShareDataService<Dashboard>,
        private deleteDataService: ShareDataService<number>,
        private toastNotificationService: ToastNotificationService,
        private spinnerService: SpinnerService,
        private confirmWindowService: ConfirmWindowService
    ) {
        super();
    }

    ngOnInit(): void {
        //to test error catching
        throw new Error();

        this.spinnerService.show();
        this.route.params
            .pipe(this.untilThis)
            .subscribe(params => this.getParams(params));
    }

    updateDashboard(dashboard: UpdateDashboard) {
        this.isEditing = false;
        this.dashboardService.updateDashboard(dashboard)
            .pipe(this.untilThis)
            .subscribe(updatedDashboard => {
                this.dashboard = updatedDashboard;
                this.updateDataService.changeMessage(this.dashboard);
                this.toastNotificationService.success('Dashboard has been updateded');
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
            });
    }

    deleteDashboard() {
        this.spinnerService.show();
        this.dashboardService.deleteDashboard(this.dashboard.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.router.navigate(['/home/projects']).then(r => r);
                this.toastNotificationService.success('Dashboard has been deleted');
                this.deleteDataService.changeMessage(this.dashboard.id);
                this.spinnerService.hide();
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
                this.spinnerService.hide();
            });
    }

    confirmDelete() {
        if (this.dashboard) {
            const confirmWindowOptions: ConfirmOptions = {
                title: `Delete ${this.dashboard.name}`,
                message: 'Are you sure you want to delete this dashboard? '
                    + 'If you delete this, then it will be impossible to undo the changes.',
                accept: () => this.deleteDashboard()
            };
            this.confirmWindowService.confirm(confirmWindowOptions);
        }
    }

    getParams(params) {
        const { id } = params;
        this.showTileMenu = false; this.dashboardService.get(id)
            .pipe(this.untilThis)
            .subscribe(dashboardById => {
                this.dashboard = dashboardById;
                this.updateSubscription$ = this.updateDataService.currentMessage
                    .subscribe((dashboard) => {
                        this.dashboard = dashboard;
                    }, error => {
                        this.toastNotificationService.error(`${error}`, 'Error', 2000);
                    });
                this.spinnerService.hide();
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
            });
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
