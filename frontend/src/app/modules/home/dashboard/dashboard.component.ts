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
import { ConfirmOptions } from '@shared/models/confirm-window/confirm-options';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { Project } from '@shared/models/projects/project';
import { TileService } from '@core/services/tile.service';
import { AuthenticationService } from '@core/services/authentication.service';
import { ProjectService } from '@core/services/project.service';
import { map } from 'rxjs/operators';
import { SpinnerService } from '@core/services/spinner.service';
import { convertJsonToTileSettings, sortTilesByTileOrder } from '@core/utils/tile.utils';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { UpdateDashboardComponent } from '../modals/dashboard/update-dashboard.component';
import { Member } from '@shared/models/member/member';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent extends BaseComponent implements OnInit, OnDestroy {
    showTileMenu: boolean = false;
    canDrag: boolean = false;
    isOrderChanged: boolean = false;
    draggableTile: Tile;
    dashboard: Dashboard;
    updateSubscription$: Subscription;
    tiles: Tile[] = [];
    tileTypes = TileType;
    projects: Project[] = [];
    updateDashboardDialog: DynamicDialogRef;
    member: Member;

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
        private projectService: ProjectService,
        private spinnerService: SpinnerService,
        private dialogService: DialogService
    ) {
        super();
    }

    ngOnInit(): void {
        this.authService.getMember().pipe(this.untilThis)
            .subscribe(member => {
                this.member = member;
                this.route.params
                    .pipe(this.untilThis)
                    .subscribe(params => this.getParams(params));
            });
    }

    openUpdateDashboardDialog() {
        this.updateDashboardDialog = this.dialogService.open(UpdateDashboardComponent, {
            header: 'Edit dashboard',
            width: '400px',
            showHeader: true,
            baseZIndex: 10000,
            data: { dashboard: this.dashboard }
        });

        this.updateDashboardDialog.onClose
            .pipe(this.untilThis)
            .subscribe((updateDashboard: UpdateDashboard) => {
                if (updateDashboard) {
                    this.dashboardService.updateDashboard(updateDashboard)
                        .pipe(this.untilThis)
                        .subscribe(updatedDashboard => {
                            this.dashboard = updatedDashboard;
                            this.updateDataService.changeMessage(this.dashboard);
                            this.toastNotificationService.success('Dashboard has been updated');
                        }, error => {
                            this.toastNotificationService.error(error);
                        });
                }
            });
    }

    deleteDashboard() {
        this.spinnerService.show(true);
        this.dashboardService.deleteDashboard(this.dashboard.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.router.navigate(['/home/projects']).then(r => r);
                this.toastNotificationService.success('Dashboard has been deleted');
                this.deleteDataService.changeMessage(this.dashboard.id);
                this.spinnerService.hide();
            }, error => {
                this.toastNotificationService.error(error);
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

        this.initProjects()
            .subscribe(() => {
                this.getDashboard(id);
                this.getDashboardTiles(+id);
            });
    }

    initProjects() {
        return this.projectService.getProjectsByOrganizationId(this.member.organizationId)
            .pipe(map(projects => {
                this.projects = projects;
            }));
    }

    getDashboard(dashboardId: string) {
        this.spinnerService.show(true);
        this.dashboardService.get(dashboardId)
            .pipe(this.untilThis)
            .subscribe(dashboardById => {
                this.dashboard = dashboardById;
                this.updateSubscription$ = this.updateDataService.currentMessage
                    .subscribe((dashboard) => {
                        this.dashboard = dashboard;
                    }, error => {
                        this.toastNotificationService.error(error);
                    });
                this.spinnerService.hide();
            }, error => {
                this.toastNotificationService.error(error);
            });
    }

    getDashboardTiles(dashboardId: number) {
        this.spinnerService.show(true);
        this.tileService.getAllTilesByDashboardId(dashboardId)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.tiles = response;
                this.spinnerService.hide();
            }, error => {
                this.toastNotificationService.error(error);
                this.spinnerService.hide();
            });
    }

    getTileSize(tile: Tile) {
        const settings = convertJsonToTileSettings(tile.settings, TileType.TopActiveIssues) as TopActiveIssuesSettings;
        return settings.tileSize * 150 + 350;
    }

    toggleTileMenu(): void {
        if (this.showTileMenu) {
            this.revertTilesOrder();
        }

        this.showTileMenu = !this.showTileMenu;
    }

    ngOnDestroy(): void {
        this.updateSubscription$.unsubscribe();
        super.ngOnDestroy();
    }

    deleteTile(tile: Tile) {
        this.spinnerService.show(true);
        this.tileService.deleteTile(tile.id)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.spinnerService.hide();
                this.tiles.splice(this.tiles.findIndex(value => value.id === tile.id), 1);
                this.toastNotificationService.success('Tile Deleted');
            }, error => {
                this.spinnerService.hide();
                this.toastNotificationService.error(error);
            });
    }

    deleteAllTiles(dashboardId: number) {
        this.tileService.deleteAllTilesByDashboardId(dashboardId)
            .pipe(this.untilThis)
            .subscribe(() => {
                this.tiles = [];
                this.toastNotificationService.success('Tile Cleared');
            }, error => {
                this.toastNotificationService.error(error);
            });
    }

    saveTilesOrder() {
        this.spinnerService.show(true);

        const orderingOfTiles = this.tiles.map((t, i) => ({ id: t.id, tileOrder: i + 1 }));

        this.tileService.setDashboardOrderForTiles(this.dashboard.id, orderingOfTiles)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.reorderTiles(response);
                this.spinnerService.hide();
                this.toastNotificationService.success('The Tiles order was successfully changed!');
                this.isOrderChanged = false;
            }, err => {
                this.spinnerService.hide();
                this.toastNotificationService.error(err);
            });
    }

    drag(tile: Tile) {
        this.draggableTile = tile;
        this.canDrag = false;
    }

    drop(num: number) {
        let insertIndex = num;
        const removeIndex = this.tiles.indexOf(this.draggableTile);

        this.tiles = this.tiles.filter(i => i.id !== this.draggableTile.id);
        if (removeIndex < insertIndex) insertIndex -= 1;

        this.tiles = [
            ...this.tiles.slice(0, insertIndex),
            this.draggableTile,
            ...this.tiles.slice(insertIndex)
        ];

        this.isOrderChanged = true;
        this.dragOff();
    }

    setDragByButton(status: boolean) {
        this.canDrag = status;
    }

    dragOff() {
        this.canDrag = false;
        this.draggableTile = null;
    }

    getDropSpaceState(index: number): boolean {
        if (!this.showTileMenu) return false;
        if (!this.draggableTile) return true;

        const tileIndex = this.tiles.indexOf(this.draggableTile);

        if (tileIndex !== index && tileIndex !== index - 1) return true;
        return false;
    }

    private revertTilesOrder() {
        this.tiles = sortTilesByTileOrder(this.tiles);
        this.isOrderChanged = false;
    }

    private reorderTiles(reorderedTiles: Tile[]) {
        this.tiles = reorderedTiles.map(tile => {
            const oldTile = this.tiles.find(t => t.id === tile.id);
            oldTile.tileOrder = tile.tileOrder;
            return oldTile;
        });
        this.tiles = sortTilesByTileOrder(this.tiles);
    }
}
