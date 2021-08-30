import { AuthenticationService } from '@core/services/authentication.service';
import { switchMap } from 'rxjs/operators';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Tile } from '@shared/models/tile/tile';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { BaseComponent } from '@core/components/base/base.component';
import { IssueInfo } from '@shared/models/issue/issue-info';
import { IssueService } from '@core/services/issue.service';
import { convertJsonToTileSettings, convertTileDateRangeTypeToMs } from '@core/utils/tile.utils';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';

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
        private toastNotificationService: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private issueService: IssueService,
        private authService: AuthenticationService,
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
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.TopActiveIssues) as TopActiveIssuesSettings;
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private applyIssuesSettings(issuesInfo: IssueInfo[]) {
        //TODO: Filter issues by 'active' issue type (future feature)
        this.displayedIssues = issuesInfo
            .filter(info =>
                info.status === IssueStatus.Active
                && this.requiredProjects.some(proj => proj.id === info.project.id
                && new Date(info.newest.occurredOn).getTime() >= Date.now() - convertTileDateRangeTypeToMs(this.tileSettings.dateRange)))
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
