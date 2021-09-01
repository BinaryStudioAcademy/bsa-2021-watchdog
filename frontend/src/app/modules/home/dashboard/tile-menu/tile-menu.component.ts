import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Tile } from '@shared/models/tile/tile';
import { Project } from '@shared/models/projects/project';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { ConfirmWindowService } from '@core/services/confirm-window.service';

@Component({
    selector: 'app-tile-menu[dashboardId][tiles][userProjects]',
    templateUrl: './tile-menu.component.html',
    styleUrls: ['./tile-menu.component.sass']
})
export class TileMenuComponent implements OnInit {
    menuListItems: MenuItem[] = [];
    menuValueItems: MenuItem[] = [];
    menuChartItems: MenuItem[] = [];
    menuTextItems: MenuItem[] = [];
    selectedItem?: MenuItem;

    @Output()
    closeMenu: EventEmitter<boolean> = new EventEmitter();
    @Output()
    clearTiles: EventEmitter<boolean> = new EventEmitter<boolean>();

    @Input() userProjects: Project[] = [];
    @Input() tiles: Tile[] = [];
    @Input() dashboardId: number;

    constructor(
        private toastNotifications: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private confirmWindowService: ConfirmWindowService
    ) {

    }

    ngOnInit(): void {
        this.initMenuListItems();
        this.initMenuChartItems();
    }

    clearDashboardTiles() {
        this.confirmWindowService.confirm({
            title: 'Delete all tiles?',
            message: 'Are you sure you wish to delete all the tiles?',
            acceptButton: { class: 'p-button-primary p-button-outlined' },
            cancelButton: { class: 'p-button-secondary p-button-outlined' },
            accept: () => this.clearTiles.emit(true),
        });
    }

    close() {
        this.closeMenu.emit(true);
    }

    listItemSelected(item?: MenuItem): void {
        switch (+item.id) {
            case TileType.TopActiveIssues:
                this.selectedItem = item;
                this.tileDialogService.showTopActiveIssuesCreateDialog(this.userProjects, this.dashboardId, this.tiles);
                break;
            default:
                this.selectedItem = undefined;
                break;
        }
    }

    chartItemSelected(item?: MenuItem): void {
        switch (+item.id) {
            case TileType.IssuesPerTime:
                this.selectedItem = item;
                this.tileDialogService.showIssuesPerTimeCreateDialog(this.userProjects, this.dashboardId, this.tiles);
                break;
            case TileType.IssuesCount:
                this.selectedItem = item;
                this.tileDialogService.showIssuesCountCreateDialog(this.userProjects, this.dashboardId, this.tiles);
                break;
            case TileType.HeatMap:
                this.selectedItem = item;
                this.tileDialogService.showHeatMapCreateDialog(this.userProjects, this.dashboardId, this.tiles);
                break;
            default:
                this.selectedItem = undefined;
                break;
        }
    }

    private initMenuListItems(): void {
        this.menuListItems = [
            {
                id: TileType.TopActiveIssues.toString(),
                label: 'Top Active Issues',
                icon: 'pi pi-ban',
                command: event => this.listItemSelected(event.item)
            },
        ];
    }

    private initMenuChartItems(): void {
        this.menuChartItems = [
            {
                id: TileType.IssuesPerTime.toString(),
                label: 'Issues Per Time',
                icon: 'pi pi-chart-bar',
                command: event => this.chartItemSelected(event.item)
            },
            {
                id: TileType.IssuesCount.toString(),
                label: 'Issues Count',
                icon: 'pi pi-th-large',
                command: event => this.chartItemSelected(event.item)
            },
            {
                id: TileType.HeatMap.toString(),
                label: 'Heat map',
                icon: 'pi pi-heart',
                command: event => this.chartItemSelected(event.item)
            },
        ];
    }
}
