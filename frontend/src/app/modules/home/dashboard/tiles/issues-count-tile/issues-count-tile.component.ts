import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Tile } from '@shared/models/tile/tile';
import { Project } from '@shared/models/projects/project';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { IssueService } from '@core/services/issue.service';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { BaseComponent } from '@core/components/base/base.component';
import { ChartOptions } from '@shared/models/charts/chart-options';
import { ChartType } from '@shared/models/charts/chart-type';
import { SingleChart } from '@shared/models/charts/single-chart';
import {
    convertJsonToTileSettings,
    convertTileDateRangeTypeToMs
} from '@core/utils/tile.utils';
import { CountIssuesSettings } from '@shared/models/tile/settings/count-issues-settings';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { IssueStatusesByDateRangeFilter } from '@shared/models/issue/issue-statuses-by-date-range-filter';
import { dateRangeTypeLabels } from '@shared/models/tile/enums/tile-date-range-type';

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
    tileSettings: CountIssuesSettings;
    requiredProjects: Project[] = [];
    dateMsNow: number;
    expectedIssueStatuses: IssueStatus[];
    status = IssueStatus;
    dateRangeLabel: string;
    dateRangeMsOffset: number;
    ChartType: ChartType = ChartType.NumberCard;
    dateMsPast: number;
    single: SingleChart[];
    chartOptions: ChartOptions;

    constructor(
        private toastNotificationService: ToastNotificationService,
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
        this.expectedIssueStatuses = [];
        this.getTileSettings();
        this.applyProjectSettings();
    }

    private getTileSettings() {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.IssuesCount) as CountIssuesSettings;
        this.dateMsNow = new Date().getTime();
        this.dateRangeMsOffset = convertTileDateRangeTypeToMs(this.tileSettings.dateRange);
        this.dateMsPast = this.dateMsNow - this.dateRangeMsOffset;
        this.expectedIssueStatuses = this.tileSettings.issueStatuses;
        this.dateRangeLabel = dateRangeTypeLabels[this.tileSettings.dateRange];
    }

    private getEventMessagesCount(project: Project): void {
        const filter: IssueStatusesByDateRangeFilter = {
            issueStatuses: this.expectedIssueStatuses,
            dateRange: new Date(Number(this.dateMsPast))
        };
        this.issueService.getFilteredIssueCountByStatusesAndDateRangeByApplicationId(project.id, filter)
            .pipe(this.untilThis)
            .subscribe(messagesCount => {
                this.single.push({
                    name: project.name,
                    value: messagesCount
                });
            }, error => {
                this.toastNotificationService.error(error);
            });
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
        this.requiredProjects.forEach(proj => {
            this.getEventMessagesCount(proj);
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

    editTile() {
        this.tileDialogService.showIssuesCountEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }
}
