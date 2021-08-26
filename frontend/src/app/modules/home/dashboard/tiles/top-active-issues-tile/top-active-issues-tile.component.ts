import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { TileService } from '@core/services/tile.service';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Tile } from '@shared/models/tile/tile';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { BaseComponent } from '@core/components/base/base.component';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { IssueService } from '@core/services/issue.service';
import { convertJsonToTileSettings, convertTileDateRangeTypeToMs } from '@core/utils/tile.utils';

@Component({
    selector: 'app-top-active-issues-tile[tile][isShownEditTileMenu][userProjects]',
    templateUrl: './top-active-issues-tile.component.html',
    styleUrls: ['./top-active-issues-tile.component.sass']
})
export class TopActiveIssuesTileComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();

    paginatorRows: number = 5;
    tileSettings: TopActiveIssuesSettings;
    requiredProjects: Project[] = [];
    displayedIssues: IssueInfo[] = [];

    constructor(
        private tileService: TileService,
        private toastNotificationService: ToastNotificationService,
        private confirmWindowService: ConfirmWindowService,
        private tileDialogService: TileDialogService,
        private issueService: IssueService,
    ) {
        super();
    }

    ngOnInit() {
        this.applySettings();
    }

    editTile() {
        this.tileDialogService.showTopActiveIssuesEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    private applySettings() {
        this.getTileSettings();
        this.applyProjectSettings();
        this.getIssuesInfo();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.TopActiveIssues);
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private applyIssuesSettings(issuesInfo: IssueInfo[]) {
        //TODO: Filter issues by requiredProjects (future feature)
        //TODO: Filter issues by 'active' issue type (future feature)
        this.displayedIssues = issuesInfo
            .filter(info => new Date(info.newest.occurredOn).getTime() >= Date.now()
                - convertTileDateRangeTypeToMs(this.tileSettings.dateRange)) // date range sort
            .sort((a, b) => b.eventsCount - a.eventsCount) // top sort
            .slice(0, this.tileSettings.issuesCount); // issues count
    }

    private getIssuesInfo() {
        //TODO: Get issues from projects of user organization
        this.issueService
            .getIssuesInfo()
            .pipe(this.untilThis)
            .subscribe(issuesInfo => {
                this.applyIssuesSettings(issuesInfo);
            }, error => {
                this.toastNotificationService.error(error);
            });
    }
}
