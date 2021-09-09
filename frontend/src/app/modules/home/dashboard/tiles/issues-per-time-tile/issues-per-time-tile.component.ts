import { Component, OnInit } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { TileService } from '@core/services/tile.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { IssueService } from '@core/services/issue.service';

import { TileType } from '@shared/models/tile/enums/tile-type';
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
    convertTileSettingsToJson,
} from '@core/utils/tile.utils';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { BaseTileComponent } from '../base-tile/base-tile.component';

@Component({
    selector: 'app-issues-per-time-tile[tile][userProjects]',
    templateUrl: './issues-per-time-tile.component.html',
    styleUrls: ['../common-tile/common-tile.component.sass']
})
export class IssuesPerTimeTileComponent extends BaseTileComponent implements OnInit {
    paginatorRows: number = 5;
    tileSettings: IssuesPerTimeSettings;
    requiredProjects: Project[] = [];
    multi: MultiChart[] = [];
    chartOptions: ChartOptions;
    ChartType = ChartType;
    dateMsNow: number;
    dateRangeMsOffset: number;
    dateMsPast: number;
    loadingDataInTile: boolean = false;

    constructor(
        private tileService: TileService,
        private toastNotificationService: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private issueService: IssueService,
    ) {
        super();
    }

    ngOnInit() {
        super.ngOnInit();
        this.initChartSettings();
        this.applySettings();
    }

    editTile() {
        this.tileDialogService.showIssuesPerTimeEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    private applySettings() {
        this.multi = [];
        this.getTileSettings();
        this.applyProjectSettings();
        this.changeTile.emit();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.IssuesPerTime) as IssuesPerTimeSettings;
        this.dateMsNow = new Date().getTime();
        this.dateRangeMsOffset = convertTileDateRangeTypeToMs(this.tileSettings.dateRange);
        this.dateMsPast = this.dateMsNow - this.dateRangeMsOffset;
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
        this.requiredProjects.forEach(proj => {
            this.getEventMessages(proj);
        });
    }

    private applyIssuesSettings(messageInfos: IssueMessageInfo[], project: Project) {
        this.multi.push({
            name: project.name,
            series: this.getMultiChartSeries(this.dateMsNow, this.dateRangeMsOffset, this.tileSettings.granularity,
                messageInfos.filter(info => new Date(info.occurredOn).getTime() >= this.dateMsPast))
        });
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

    //please delete this method when all old tile issue statuses will be removed
    // this method was added only to maintain compatibility with older types
    // it will remove old issue statuses and set default(all)
    fixTileIssueStatus(statuses: IssueStatus[]) {
        this.tileSettings.issueStatuses = statuses.length
            ? statuses
            : [IssueStatus.Active, IssueStatus.Resolved, IssueStatus.Ignored] as IssueStatus[];
        this.tile.settings = convertTileSettingsToJson(this.tileSettings);
        this.tileService
            .updateTile(this.tile)
            .pipe(this.untilThis)
            .subscribe(response => {
                this.tile = response;
                this.applySettings();
            }, error => {
                this.toastNotificationService.error(error);
            });
    }

    private getEventMessages(project: Project): void {
        //please remove the condition and leave only getEventMessagesInfoByProjectIdFilteredByStatuses method
        const statuses = this.tileSettings.issueStatuses.filter(value => Object.values(IssueStatus).includes(value));
        if (this.tileSettings.issueStatuses.length !== statuses.length) {
            this.fixTileIssueStatus(statuses);
        } else {
            this.issueService
                .getEventMessagesInfoByProjectIdFilteredByStatuses(project.id, { issueStatuses: this.tileSettings.issueStatuses })
                .pipe(this.untilThis)
                .subscribe(messagesInfo => {
                    this.applyIssuesSettings(messagesInfo, project);
                    this.loadingDataInTile = true;
                }, error => {
                    this.toastNotificationService.error(error);
                });
        }
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
