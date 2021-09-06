import { AuthenticationService } from '@core/services/authentication.service';
import { switchMap } from 'rxjs/operators';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
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
import html2canvas from 'html2canvas';
import { jsPDF } from 'jspdf';
import * as FileSaver from 'file-saver';
import 'blob';
import { ExportType } from '@shared/models/tile/enums/export-type';

const JsPDF = jsPDF;

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
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
    paginatorRows: number = 5;
    tileSettings: TopActiveIssuesSettings;
    requiredProjects: Project[] = [];
    displayedIssues: IssueInfo[] = [];
    @ViewChild('tiles') data: any;

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

    setTileDragStatus(status: boolean) {
        this.dragTile.emit(status);
    }

    private applySettings() {
        this.getTileSettings();
        this.applyProjectSettings();
        this.getIssuesInfo();
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
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.TopActiveIssues) as TopActiveIssuesSettings;
    }

    private applyProjectSettings() {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    private applyIssuesSettings(issuesInfo: IssueInfo[]) {
        this.displayedIssues = issuesInfo
            .filter(info => this.requiredProjects.some(proj => proj.id === info.project.id)
                && new Date(info.newest.occurredOn).getTime() >= Date.now() - convertTileDateRangeTypeToMs(this.tileSettings.dateRange))
            .sort((a, b) => b.eventsCount - a.eventsCount) // top sort
            .slice(0, this.tileSettings.issuesCount); // issues count
    }

    private getIssuesInfo() {
        this.authService.getMember()
            .pipe(this.untilThis, switchMap(member => this.issueService.getIssuesInfo(member.id, IssueStatus.Active)))
            .subscribe(issuesInfo => {
                this.applyIssuesSettings(issuesInfo);
            }, error => {
                this.toastNotificationService.error(error);
            });
    }
}
