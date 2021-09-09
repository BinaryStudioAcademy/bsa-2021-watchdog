import { AuthenticationService } from '@core/services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { TopActiveTileSettings } from '@shared/models/tile/settings/top-active-tile-settings';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { IssueService } from '@core/services/issue.service';
import { convertJsonToTileSettings, convertTileDateRangeTypeToMs } from '@core/utils/tile.utils';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';
import { BaseTileComponent } from '../base-tile/base-tile.component';

@Component({
    selector: 'app-top-active-issues-tile[tile][userProjects]',
    templateUrl: './top-active-issues-tile.component.html',
    styleUrls: ['./top-active-issues-tile.component.sass']
})
export class TopActiveIssuesTileComponent extends BaseTileComponent implements OnInit {
    tileSettings: TopActiveTileSettings;
    requiredProjects: Project[] = [];
    displayedIssues: IssueInfo[] = [];
    loadingDataInTile: boolean = false;

    constructor(
        private toastNotificationService: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private issueService: IssueService,
        private authService: AuthenticationService,
    ) {
        super();
    }

    ngOnInit() {
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
        this.tileDialogService.showTopResponsesTimeEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    private applySettings() {
        this.getTileSettings();
        this.applyProjectSettings();
        this.getIssuesInfo();
        this.changeTile.emit();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.TopActiveIssues) as TopActiveTileSettings;
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private getIssuesInfo() {
        this.issueService.getTopActiveIssuesInfo({
            projectIds: this.requiredProjects.map(x => x.id),
            date: new Date(Date.now() - convertTileDateRangeTypeToMs(this.tileSettings.dateRange)),
            items: this.tileSettings.itemsCount
        })
            .pipe(this.untilThis)
            .subscribe(issuesInfo => {
                this.displayedIssues = issuesInfo;
                this.loadingDataInTile = true;
            }, error => {
                this.toastNotificationService.error(error);
                this.loadingDataInTile = true;
            });
    }
}
