import { Component, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { convertJsonToTileSettings } from '@core/utils/tile.utils';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { AnalyticsService } from '@core/services/analytics.service';
import { ResponseInfo } from '@shared/models/analytics/response-info';
import { TopActiveTileSettings } from '@shared/models/tile/settings/top-active-tile-settings';
import { BaseTileComponent } from '@modules/home/dashboard/tiles/base-tile/base-tile.component';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';

@Component({
    selector: 'app-top-responses-time-tile',
    templateUrl: './top-responses-time-tile.component.html',
    styleUrls: ['./top-responses-time-tile.component.sass']
})
export class TopResponsesTimeTileComponent extends BaseTileComponent implements OnInit {
    tileSettings: TopActiveTileSettings;
    requiredProjects: Project[] = [];
    displayedResponses: ResponseInfo[] = [];
    loadingDataInTile: boolean = false;

    constructor(
        private toastNotificationService: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private analyticsService: AnalyticsService,
    ) {
        super();
    }

    ngOnInit(): void {
        super.ngOnInit();
        this.applySettings();
    }

    paginatorRows() {
        switch (this.tileSettings.tileSize) {
            case TileSizeType.Small:
                return 3;
            case TileSizeType.Medium:
                return 4;
            case TileSizeType.Large:
                return 5;
            default:
                return 3;
        }
    }

    editTile() {
        this.tileDialogService.showTopActiveIssuesEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    private applySettings() {
        this.getTileSettings();
        this.applyProjectSettings();
        this.getResponsesInfo();
        this.changeTile.emit();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.TopResponsesTime) as TopActiveTileSettings;
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private getResponsesInfo() {
        this.analyticsService.getResponsesInfo(this.requiredProjects, this.tileSettings.dateRange, this.tileSettings.itemsCount)
            .pipe(this.untilThis)
            .subscribe(responsesInfo => {
                this.displayedResponses = responsesInfo;
                this.loadingDataInTile = true;
            }, error => {
                this.toastNotificationService.error(error);
            });
    }
}
