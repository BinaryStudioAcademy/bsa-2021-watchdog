import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Tile } from '@shared/models/tile/tile';
import { Project } from '@shared/models/projects/project';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { BaseComponent } from '@core/components/base/base.component';
import { convertJsonToTileSettings } from '@core/utils/tile.utils';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { AnalyticsService } from '@core/services/analytics.service';
import { ResponseInfo } from '@shared/models/analytics/response-info';
import { TopActiveTileSettings } from '@shared/models/tile/settings/top-active-tile-settings';

@Component({
    selector: 'app-top-responses-time-tile',
    templateUrl: './top-responses-time-tile.component.html',
    styleUrls: ['./top-responses-time-tile.component.sass']
})
export class TopResponsesTimeTileComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
    paginatorRows: number = 5;
    tileSettings: TopActiveTileSettings;
    requiredProjects: Project[] = [];
    displayedResponses: ResponseInfo[];

    constructor(
        private toastNotificationService: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private analyticsService: AnalyticsService
    ) {
        super();
    }

    ngOnInit(): void {
        this.applySettings();
    }

    editTile() {
        this.tileDialogService.showTopActiveIssuesEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    setTileDragStatus(status: boolean) {
        this.dragTile.emit(status);
    }

    private applySettings() {
        this.getTileSettings();
        this.applyProjectSettings();
        this.getResponsesInfo();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.TopResponsesTime) as TopActiveTileSettings;
        console.log(this.tileSettings);
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private getResponsesInfo() {
        console.log(this.tileSettings);
        this.analyticsService.getResponsesInfo(this.requiredProjects, this.tileSettings.dateRange, this.tileSettings.itemsCount)
            .pipe(this.untilThis)
            .subscribe(responsesInfo => {
                this.displayedResponses = responsesInfo;
            }, error => {
                this.toastNotificationService.error(error);
            });
    }
}
