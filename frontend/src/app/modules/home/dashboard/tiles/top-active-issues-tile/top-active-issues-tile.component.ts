import { AuthenticationService } from '@core/services/authentication.service';
import { switchMap } from 'rxjs/operators';
import { Component, Input, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { IssueService } from '@core/services/issue.service';
import { convertJsonToTileSettings, convertTileDateRangeTypeToMs } from '@core/utils/tile.utils';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';
import { BaseTileComponent } from '../base-tile/base-tile.component';

@Component({
    selector: 'app-top-active-issues-tile[tile][userProjects]',
    templateUrl: './top-active-issues-tile.component.html',
    styleUrls: ['./top-active-issues-tile.component.sass']
})
export class TopActiveIssuesTileComponent extends BaseTileComponent implements OnInit {

    tileSettings: TopActiveIssuesSettings;
    requiredProjects: Project[] = [];
    displayedIssues: IssueInfo[] = [];

    constructor(
        private toastNotificationService: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private issueService: IssueService,
        private authService: AuthenticationService,
    ) {
        super();
    }

    ngOnInit() {
        this.applySettings();
        this.events.pipe(this.untilThis)
            .subscribe(() => this.editTile());
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
                return 3
        }

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
        this.getIssuesInfo();
        this.changeTile.emit();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.TopActiveIssues) as TopActiveIssuesSettings;
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private applyIssuesSettings(issuesInfo: IssueInfo[]) {
        this.displayedIssues = issuesInfo
            .filter(info =>
                info.status === IssueStatus.Active
                && this.requiredProjects.some(proj => proj.id === info.project.id
                    && new Date(info.newest.occurredOn)
                        .getTime() >= Date.now() - convertTileDateRangeTypeToMs(this.tileSettings.dateRange)))
            .sort((a, b) => b.eventsCount - a.eventsCount) // top sort
            .slice(0, this.tileSettings.issuesCount); // issues count
    }

    private getIssuesInfo() {
        this.authService.getMember()
            .pipe(this.untilThis, switchMap(member => this.issueService.getIssuesInfo(member.id)))
            .subscribe(issuesInfo => {
                this.applyIssuesSettings(issuesInfo);
            }, error => {
                this.toastNotificationService.error(error);
            });
    }
}
