import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Tile } from '@shared/models/tile/tile';
import { Project } from '@shared/models/projects/project';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { IssueService } from '@core/services/issue.service';

import { TileType } from '@shared/models/tile/enums/tile-type';
import { BaseComponent } from '@core/components/base/base.component';
import { IssueMessageInfo } from '@shared/models/issue/issue-message-info';
import { MultiChart } from '@shared/models/charts/multi-chart';
import { ChartOptions } from '@shared/models/charts/chart-options';
import { SingleChart } from '@shared/models/charts/single-chart';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import {
    convertDateToTileGranularityTimeStamp,
    convertJsonToTileSettings,
    convertTileGranularityTypeToMs,
    convertTileSettingsToJson,
    convertTilHeatMapDateRangeTypeToMs,
} from '@core/utils/tile.utils';
import { HeatMapSettings } from '@shared/models/tile/settings/heat-map.settings';
import { ChartType } from '@shared/models/charts/chart-type';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { TileService } from '@core/services/tile.service';

@Component({
    selector: 'app-heat-map[tile][isShownEditTileMenu][userProjects]',
    templateUrl: './heat-map.component.html',
    styleUrls: ['./heat-map.component.sass']
})
export class HeatMapComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
    tileSettings: HeatMapSettings;
    requiredProjects: Project[] = [];
    multi: MultiChart[] = [];
    chartOptions: ChartOptions;
    ChartType = ChartType;
    dateMsNow: number;
    dateRangeMsOffset: number;
    dateMsPast: number;
    colorScheme = {
        domain: ['#146738', ' #2C9653', '#6CBA67', ' #A9D770',
            '#DBED91', '#FDDE90', '#FAAD67', '#EF6D49', '#D3342D', '#A10A28']
    };

    constructor(
        private toastNotificationService: ToastNotificationService,
        private tileDialogService: TileDialogService,
        private issueService: IssueService,
        private tileService: TileService
    ) {
        super();
    }

    ngOnInit() {
        this.initChartSettings();
        this.applySettings();
    }

    editTile() {
        this.tileDialogService.showHeatMapEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    setTileDragStatus(status: boolean) {
        this.dragTile.emit(status);
    }

    private applySettings() {
        this.multi = [];
        this.getTileSettings();
        this.applyProjectSettings();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.HeatMap) as HeatMapSettings;
        this.dateMsNow = new Date().getTime();
        this.dateRangeMsOffset = convertTilHeatMapDateRangeTypeToMs(this.tileSettings.dateRange);
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
        const issuesPerTime: { [time: number]: number } = { };
        const dateMsNow = convertDateToTileGranularityTimeStamp(granularityType, dateNow);
        const dateMsPast = convertDateToTileGranularityTimeStamp(granularityType, dateMsNow - dateRangeMsOffset);
        const granularityOffset = convertTileGranularityTypeToMs(granularityType);

        for (let i = dateMsNow, temp = 0; i > dateMsPast; i -= granularityOffset) {
            issuesPerTime[i] = 0;
            temp = i;
            eventsInfo.forEach((info) => {
                const timeStamp = convertDateToTileGranularityTimeStamp(granularityType, info.occurredOn);
                if ((temp >= timeStamp) && (temp - granularityOffset <= timeStamp)) {
                    issuesPerTime[i] += 1;
                }
            });
        }

        return Object.entries(issuesPerTime).map<SingleChart>(([key, val]) => ({
            name: new Date(+key),
            value: val
        }));
    }

    private getEventMessages(project: Project): void {
        const statuses = this.tileSettings.issueStatuses.filter(value => Object.values(IssueStatus).includes(value));
        if (this.tileSettings.issueStatuses.length !== statuses.length) {
            this.fixTileIssueStatus(statuses);
        } else {
            this.issueService
                .getEventMessagesInfoByProjectIdFilteredByStatuses(project.id, { issueStatuses: this.tileSettings.issueStatuses })
                .pipe(this.untilThis)
                .subscribe(messagesInfo => {
                    this.applyIssuesSettings(messagesInfo, project);
                }, error => {
                    this.toastNotificationService.error(error);
                });
        }
    }

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

    private initChartSettings(): void {
        this.chartOptions = {
            showLegend: false,
            showLabels: true,
            animations: true,
            showXAxis: true,
            showYAxis: true,
            showYAxisLabel: false,
            showXAxisLabel: false,
            colorScheme: this.colorScheme
        };
    }
}
