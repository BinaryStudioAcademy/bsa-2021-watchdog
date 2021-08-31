import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Tile } from '@shared/models/tile/tile';
import { Project } from '@shared/models/projects/project';
import { TileService } from '@core/services/tile.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { IssueService } from '@core/services/issue.service';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { BaseComponent } from '@core/components/base/base.component';
import { IssueMessageInfo } from '@shared/models/issue/issue-message-info';
import { ChartOptions } from '@shared/models/charts/chart-options';
import { ChartType } from '@shared/models/charts/chart-type';
import { SingleChart } from '@shared/models/charts/single-chart';
import {
    convertJsonToTileSettings,
    convertTileDateRangeTypeToMs
} from '@core/utils/tile.utils';
import { CountIssuesSettings } from '@shared/models/tile/settings/count-issues-settings';

@Component({
    selector: 'app-issues-count-tile[tile][isShownEditTileMenu][userProjects]',
    templateUrl: './issues-count-tile.component.html',
    styleUrls: ['./issues-count-tile.component.sass']
})
export class IssuesCountTileComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();
    paginatorRows: number = 5;
    tileSettings: CountIssuesSettings;
    requiredProjects: Project[] = [];
    dateMsNow: number;
    dateRangeMsOffset: number;
    ChartType: ChartType = ChartType.NumberCard;
    dateMsPast: number;
    single: SingleChart[];
    chartOptions: ChartOptions;

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
        this.initChartSettings();
        this.applySettings();
    }

    private applySettings() {
        this.single = [];
        this.getTileSettings();
        this.applyProjectSettings();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.IssuesCount) as CountIssuesSettings;
        this.dateMsNow = new Date().getTime();
        this.dateRangeMsOffset = convertTileDateRangeTypeToMs(this.tileSettings.dateRange);
        this.dateMsPast = this.dateMsNow - this.dateRangeMsOffset;
    }

    private getEventMessages(project: Project): void {
        this.issueService
            .getEventMessagesInfoByProjectId(project.id)
            .pipe(this.untilThis)
            .subscribe(messagesInfo => {
                this.applyIssuesSettings(messagesInfo, project);
            }, error => {
                this.toastNotificationService.error(error);
            });
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
        this.requiredProjects.forEach(proj => {
            this.getEventMessages(proj);
        });
    }

    private applyIssuesSettings(messageInfos: IssueMessageInfo[], project: Project) {
        //TODO: Filter issues by issue status type (future feature)
        this.single.push({
            name: project.name,
            value: messageInfos.filter(info => this.checkDateRange(info)).length
        });
    }

    checkDateRange(messageInfo: IssueMessageInfo): boolean {
        return new Date(messageInfo.occurredOn).getTime() >= this.dateMsPast;
    }

    private initChartSettings(): void {
        this.chartOptions = {
            animations: true,
            gradient: true,
            showXAxis: true,
            showYAxis: true,
            autoScale: true,
            roundDomains: true,
            showLegend: false,
            timeline: false,
            showXAxisLabel: false,
            showYAxisLabel: false,
        };
    }

    editTile() {
        this.tileDialogService.showIssuesCountEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }
}
