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
import { MultiChart } from '@shared/models/charts/multi-chart';
import { ChartOptions } from '@shared/models/charts/chart-options';
import { ChartType } from '@shared/models/charts/chart-type';
import { IssuesPerTimeSettings } from '@shared/models/tile/settings/issues-per-time-settings';
import { SingleChart } from '@shared/models/charts/single-chart';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import {
    convertDateToTileGranularityTimeStamp,
    convertJsonToTileSettings,
    convertTileDateRangeTypeToMs,
    convertTileGranularityTypeToMs,
} from '@core/utils/tile.utils';

@Component({
    selector: 'app-issues-per-time-tile[tile][isShownEditTileMenu][userProjects]',
    templateUrl: './issues-per-time-tile.component.html',
    styleUrls: ['./issues-per-time-tile.component.sass']
})
export class IssuesPerTimeTileComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();
    paginatorRows: number = 5;
    tileSettings: IssuesPerTimeSettings;
    requiredProjects: Project[] = [];
    multi: MultiChart[] = [];
    chartOptions: ChartOptions;
    ChartType = ChartType;
    isLoading: boolean = true;

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

    editTile() {
        this.tileDialogService.showIssuesPerTimeEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    private applySettings() {
        this.isLoading = true;
        this.getTileSettings();
        this.applyProjectSettings();
        this.getEventMessages();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.IssuesPerTime) as IssuesPerTimeSettings;
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private applyIssuesSettings(messageInfos: IssueMessageInfo[]) {
        //please, be careful with Date in all this methods
        const dateMsNow = new Date().getTime();
        const dateRangeMsOffset = convertTileDateRangeTypeToMs(this.tileSettings.dateRange);
        const dateMsPast = dateMsNow - dateRangeMsOffset;
        //TODO: Filter issues by issue status type (future feature)
        //TODO: Set multi.series by project issue events info

        this.multi = this.requiredProjects.map<MultiChart>(value => ({
            name: value.name,
            series: this.getMultiChartSeries(dateMsNow, dateRangeMsOffset, this.tileSettings.granularity,
                messageInfos.filter(info => new Date(info.occurredOn).getTime() >= dateMsPast))
        }));
        this.isLoading = false;
    }

    private getMultiChartSeries(
        dateNow: Date | number, dateRangeMsOffset: number, granularityType: TileGranularityType, eventsInfo: IssueMessageInfo[]
    ) {
        const issuesPerTime: { [time: number]: number } = {};

        const dateMsNow = convertDateToTileGranularityTimeStamp(granularityType, dateNow);
        const dateMsPast = convertDateToTileGranularityTimeStamp(granularityType, dateMsNow - dateRangeMsOffset);
        const granularityOffset = convertTileGranularityTypeToMs(granularityType);

        // filling keys with date (i) and value with issue count (0)
        for (let i = dateMsPast; i < dateMsNow; i += granularityOffset) {
            issuesPerTime[i] = 0;
        }

        // filling count
        eventsInfo.forEach((info) => {
            const timeStamp = convertDateToTileGranularityTimeStamp(granularityType, info.occurredOn);
            if (issuesPerTime[timeStamp]) {
                issuesPerTime[timeStamp] += 1;
            } else {
                issuesPerTime[timeStamp] = 1;
            }
        });

        return Object.entries(issuesPerTime).map<SingleChart>(([key, val]) => ({
            name: new Date(+key),
            value: val
        }));
    }

    private getEventMessages(): void {
        //TODO: Get issues from projects of user organization
        this.issueService
            .getEventMessagesInfo()
            .pipe(this.untilThis)
            .subscribe(messagesInfo => {
                this.applyIssuesSettings(messagesInfo);
            }, error => {
                this.toastNotificationService.error(error);
            });
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
}
