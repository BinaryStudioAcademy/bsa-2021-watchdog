import { Component, OnDestroy, OnInit } from '@angular/core';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardService } from '@core/services/dashboard.service';
import { ShareDataService } from '@core/services/share-data.service';
import { Subscription } from 'rxjs';
import { BaseComponent } from '@core/components/base/base.component';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { Tile } from '@shared/models/tile/tile';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Issue } from '@shared/models/issue/issue';
import { ConfirmOptions } from '@shared/models/confirm-window/confirm-options';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { Project } from '@shared/models/projects/project';
import { TileService } from '@core/services/tile.service';
import { User } from '@shared/models/user/user';
import { Organization } from '@shared/models/organization/organization';
import { AuthenticationService } from '@core/services/authentication.service';
import { ProjectService } from '@core/services/project.service';
import { map } from 'rxjs/operators';

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
    user: User;
    organization: Organization;
    isLoading: boolean = false;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private dashboardService: DashboardService,
        private updateDataService: ShareDataService<Dashboard>,
        private deleteDataService: ShareDataService<number>,
        private toastNotificationService: ToastNotificationService,
        private confirmWindowService: ConfirmWindowService,
        private tileService: TileService,
        private authService: AuthenticationService,
        private projectService: ProjectService
    ) {
        super();
    }

    ngOnInit(): void {
        this.user = this.authService.getUser();
        this.authService.getOrganization()
            .pipe(this.untilThis)
            .subscribe(organization => {
                this.organization = organization;

                this.route.params
                    .pipe(this.untilThis)
                    .subscribe(params => this.getParams(params));
            });
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
        this.isLoading = true;
        this.dashboardService.deleteDashboard(this.dashboard.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.router.navigate(['/home/projects']).then(r => r);
                this.toastNotificationService.success('Dashboard has been deleted');
                this.deleteDataService.changeMessage(this.dashboard.id);
                this.isLoading = false;
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
                this.isLoading = false;
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

        this.initProjects()
            .subscribe(() => {
                //TODO: Get issues of all currentUser projects
                this.initFakeIssues();

                this.getDashboard(id);
                this.getDashboardTiles(+id);
            });
    }

    initProjects() {
        return this.projectService
            .getProjectsByOrganizationId(this.organization.id)
            .pipe(map(projects => {
                this.projects = projects;
            }));
    }

    getDashboard(dashboardId: string) {
        this.isLoading = true;
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
                this.isLoading = false;
            }, error => {
                this.toastNotificationService.error(`${error}`, '', 2000);
            });
    }

    getDashboardTiles(dashboardId: number) {
        this.isLoading = true;
        this.tileService.getAllTilesByDashboardId(dashboardId)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.tiles = response;
                this.isLoading = false;
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
                this.isLoading = false;
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
        this.isLoading = true;
        this.tileService.deleteTile(tile.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.isLoading = false;
                this.tiles.splice(this.tiles.findIndex(value => value.id === tile.id), 1);
                this.toastNotificationService.success('Tile Deleted');
            }, error => {
                this.isLoading = false;
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
}
