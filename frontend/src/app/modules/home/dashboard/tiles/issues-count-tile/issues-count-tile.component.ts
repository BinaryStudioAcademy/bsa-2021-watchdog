import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
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
import { ExportType } from '@shared/models/tile/enums/export-type';
import html2canvas from 'html2canvas';
import { jsPDF } from 'jspdf';
import * as FileSaver from 'file-saver';
import 'blob';

const JsPDF = jsPDF;

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
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
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
    @ViewChild('tiles') data: any;

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

    setTileDragStatus(status: boolean) {
        this.dragTile.emit(status);
    }

    private applySettings() {
        this.single = [];
        this.expectedIssueStatuses = [];
        this.getTileSettings();
        this.applyProjectSettings();
    }

    exportTile(exportType: ExportType) {
        const data = this.data.host.nativeElement;
        const smallPdf = 300;
        const mediumPdf = 440;
        const bigPdf = 880;
        html2canvas(data).then(canvas => {
            if (exportType === ExportType.Jpg) {
                canvas.toBlob((blob) => {
                    FileSaver.saveAs(blob, `${new Date().toLocaleString().replace(':', '_')}.jpg`);
                });
            }
            if (exportType === ExportType.Png) {
                canvas.toBlob((blob) => {
                    FileSaver.saveAs(blob, `${new Date().toLocaleString().replace(':', '_')}.png`);
                });
            }
            if (exportType === ExportType.Pdf) {
                const contentDataURL = canvas.toDataURL('image/png', 1.0);
                const pdf = new JsPDF('p', 'mm', 'a4');
                if (data.clientWidth >= smallPdf && data.clientWidth <= mediumPdf) {
                    pdf.addImage(contentDataURL, 'PNG', 60, 10, canvas.height / 6, 0);
                }
                if (data.clientWidth >= mediumPdf && data.clientWidth <= bigPdf) {
                    pdf.addImage(contentDataURL, 'PNG', 35, 10, canvas.height / 4, 0);
                }
                if (data.clientWidth >= bigPdf) {
                    pdf.addImage(contentDataURL, 'PNG', 0, 10, canvas.height / 2.7, 0);
                }
                pdf.save(`${new Date().toLocaleString().replace(':', '_')}.pdf`);
            }
        });
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
            colorScheme: {
                domain: ['#1c80cf']
            }
        };
    }

    editTile() {
        this.tileDialogService.showIssuesCountEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }
}
