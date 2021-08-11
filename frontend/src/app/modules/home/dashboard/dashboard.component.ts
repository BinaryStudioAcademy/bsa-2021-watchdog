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
import { TileType } from '@shared/models/tile/tile-type';
import { TileCategory } from '@shared/models/tile/tile-category';
import { Issue } from '@shared/models/issue/issue';
import { ConfirmOptions } from '@shared/models/confirm-window/confirm-options';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { Project } from '@shared/models/projects/project';
import { NewTile } from '@shared/models/tile/new-tile';

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
        private confirmWindowService: ConfirmWindowService
    ) {
        super();
    }

    ngOnInit(): void {
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
        //TODO: Get real tiles of currentDashboard
        this.initFakeTiles(id as number);

        this.getDashboard(id);
    }

    getDashboard(dashboardId: string) {
        this.dashboardService.get(dashboardId)
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

    clearTiles() {
        this.tiles = [];
        this.toastNotificationService.warning('Tiles Cleared');
    }

    deleteTile(tile: Tile) {
        console.log(tile);
        this.tiles.splice(this.tiles.findIndex(value => value.id === tile.id), 1);
        this.toastNotificationService.success('Tile Deleted');
        //TODO: delete tile
    }

    private initFakeTiles(dashboardId: number) {
        this.tiles = [{
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Top Active Issues',
            id: 1,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":1,"sourceProjects":[1,2,4],"dateRange":1}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'My Issues',
            id: 2,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":3,"sourceProjects":[1,3,4],"dateRange":2}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Cool Issues',
            id: 3,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":22,"sourceProjects":[1,2],"dateRange":0}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Test Issues',
            id: 4,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":2,"sourceProjects":[1,2],"dateRange":3}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Info Issues',
            id: 5,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":4,"sourceProjects":[1,2,4],"dateRange":2}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Main Issues',
            id: 6,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":1,"sourceProjects":[1,2,3],"dateRange":3}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Strange Issues',
            id: 7,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":3,"sourceProjects":[2,3,4],"dateRange":2}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Core Issues',
            id: 8,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":6,"sourceProjects":[3,4],"dateRange":1}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Good Issues',
            id: 9,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":7,"sourceProjects":[2,3],"dateRange":1}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'Issues',
            id: 10,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":5,"sourceProjects":[3,4],"dateRange":3}'
        },
        {
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            dashboardId,
            name: 'One Issue',
            id: 11,
            createdBy: 1,
            settings: '{"tileType":0,"issuesCount":1,"sourceProjects":[1,2,3,4],"dateRange":2}'
        }
        ];
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
