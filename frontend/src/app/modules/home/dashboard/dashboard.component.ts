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
import { Tile } from '@shared/models/tile/tile';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Issue } from '@shared/models/issue/issue';
import { ConfirmOptions } from '@shared/models/confirm-window/confirm-options';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { Project } from '@shared/models/projects/project';
import { TileService } from '@core/services/tile.service';

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
    tiles: Tile[] = [];
    tileTypes = TileType;
    issues: Issue[] = [];
    projects: Project[] = [];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private dashboardService: DashboardService,
        private updateDataService: ShareDataService<Dashboard>,
        private deleteDataService: ShareDataService<number>,
        private toastNotificationService: ToastNotificationService,
        private spinnerService: SpinnerService,
        private confirmWindowService: ConfirmWindowService,
        private tileService: TileService
    ) {
        super();
    }

    ngOnInit(): void {
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
                this.toastNotificationService.success('Dashboard has been updated');
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
                accept: () => this.deleteDashboard(),
                acceptButton: { class: 'p-button-primary p-button-outlined' },
                cancelButton: { class: 'p-button-secondary p-button-outlined' }
            };
            this.confirmWindowService.confirm(confirmWindowOptions);
        }
    }

    getParams(params) {
        const { id } = params;

        //TODO: Get projects of currentUser as member or author
        this.initFakeProjects();
        //TODO: Get issues of all currentUser projects
        this.initFakeIssues();

        this.getDashboard(id);
        this.getDashboardTiles(+id);
    }

    getDashboard(dashboardId: string) {
        this.spinnerService.show();
        this.dashboardService.get(dashboardId)
            .pipe(this.untilThis)
            .subscribe(dashboardById => {
                this.dashboard = dashboardById;
                this.updateSubscription$ = this.updateDataService.currentMessage
                    .subscribe((dashboard) => {
                        this.dashboard = dashboard;
                    }, error => {
                        this.toastNotificationService.error(`${error}`, '', 2000);
                    });
                this.spinnerService.hide();
            }, error => {
                this.toastNotificationService.error(`${error}`, '', 2000);
            });
    }

    getDashboardTiles(dashboardId: number) {
        this.spinnerService.show();
        this.tileService.getAllTilesByDashboardId(dashboardId)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.tiles = response;
                this.spinnerService.hide();
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
                this.spinnerService.hide();
            });
    }

    toggleTileMenu(): void {
        this.showTileMenu = !this.showTileMenu;
    }

    ngOnDestroy(): void {
        this.updateSubscription$.unsubscribe();
        super.ngOnDestroy();
    }

    deleteTile(tile: Tile) {
        this.spinnerService.show();
        this.tileService.deleteTile(tile.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.spinnerService.hide();
                this.tiles.splice(this.tiles.findIndex(value => value.id === tile.id), 1);
                this.toastNotificationService.success('Tile Deleted');
            }, error => {
                this.spinnerService.hide();
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
            });
    }

    deleteAllTiles(dashboardId: number) {
        this.tileService.deleteAllTilesByDashboardId(dashboardId)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.tiles = [];
                this.toastNotificationService.success('Tile Cleared');
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
            });
    }

    private initFakeIssues() {
        this.issues = [{
            name: 'Issue 1',
            events: 5,
            description: 'info',
            isNew: true,
            users: undefined,
            projectTag: 'info',
            createdAt: undefined
        },
        {
            name: 'Issue 2',
            events: 1,
            description: 'info',
            isNew: true,
            users: undefined,
            projectTag: 'info',
            createdAt: undefined
        }, {
            name: 'Issue 3',
            events: 3,
            description: 'info',
            isNew: true,
            users: undefined,
            projectTag: 'info',
            createdAt: undefined
        },
        {
            name: 'Issue 4',
            events: 2,
            description: 'info',
            isNew: true,
            users: undefined,
            projectTag: 'info',
            createdAt: undefined
        }, {
            name: 'Issue 5',
            events: 8,
            description: 'info',
            isNew: true,
            users: undefined,
            projectTag: 'info',
            createdAt: undefined
        },
        {
            name: 'Issue 6',
            events: 66,
            description: 'info',
            isNew: true,
            users: undefined,
            projectTag: 'info',
            createdAt: undefined
        },
        {
            name: 'Issue 7',
            events: 11,
            description: 'info',
            isNew: true,
            users: undefined,
            projectTag: 'info',
            createdAt: undefined
        }];
    }

    private initFakeProjects() {
        this.projects = [
            {
                name: 'DotNet App',
                description: 'Cool DotNet App',
                id: 1,
                platform: undefined,
                team: undefined
            },
            {
                name: 'JavaScript App',
                description: 'Cool JavaScript App',
                id: 2,
                platform: undefined,
                team: undefined
            },
            {
                name: 'IOS App',
                description: 'Cool IOS App',
                id: 3,
                platform: undefined,
                team: undefined
            },
            {
                name: 'Python App',
                description: 'Cool Python App',
                id: 4,
                platform: undefined,
                team: undefined
            },
        ];
    }
}
