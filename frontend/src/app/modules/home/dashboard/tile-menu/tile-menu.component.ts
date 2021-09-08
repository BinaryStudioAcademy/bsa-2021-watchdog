import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Tile } from '@shared/models/tile/tile';
import { Project } from '@shared/models/projects/project';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { ConfirmWindowService } from '@core/services/confirm-window.service';

@Component({
    selector: 'app-tile-menu[dashboardId][tiles][userProjects]',
    templateUrl: './tile-menu.component.html',
    styleUrls: ['./tile-menu.component.sass']
})
export class TileMenuComponent {
    @Output()
    closeMenu: EventEmitter<boolean> = new EventEmitter();
    @Output()
    clearTiles: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output()
    saveTilesOrder: EventEmitter<void> = new EventEmitter<void>();

    @Input() userProjects: Project[] = [];
    @Input() tiles: Tile[] = [];
    @Input() dashboardId: number;
    @Input() orderChanged: boolean;

    constructor(
        private tileDialogService: TileDialogService,
        private confirmWindowService: ConfirmWindowService
    ) { }

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

    saveOrder() {
        this.saveTilesOrder.emit();
    }

    createActiveIssues() {
        this.tileDialogService.showTopActiveIssuesCreateDialog(this.userProjects, this.dashboardId, this.tiles);
    }

    createIssuePerTime() {
        this.tileDialogService.showIssuesPerTimeCreateDialog(this.userProjects, this.dashboardId, this.tiles);
    }

    createIssueCount() {
        this.tileDialogService.showIssuesCountCreateDialog(this.userProjects, this.dashboardId, this.tiles);
    }

    createHeatMap() {
        this.tileDialogService.showHeatMapCreateDialog(this.userProjects, this.dashboardId, this.tiles);
    }

    createMostCommonCountries() {
        this.tileDialogService.showMostCommonCountriesCreateDialog(this.userProjects, this.dashboardId, this.tiles);
    }
}
