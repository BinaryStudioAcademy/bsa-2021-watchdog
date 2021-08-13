import { Injectable, OnDestroy } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AddEditTopActiveIssuesTileComponent }
    from '@modules/home/modals/tiles/top-active-issues/add-edit-top-active-issues-tile/add-edit-top-active-issues-tile.component';
import { Project } from '@shared/models/projects/project';
import { Tile } from '@shared/models/tile/tile';
import { NewTile } from '@shared/models/tile/new-tile';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { TileService } from '@core/services/tile.service';
import { BaseComponent } from '@core/components/base/base.component';
import { SpinnerService } from '@core/services/spinner.service';

@Injectable({
    providedIn: 'root'
})
export class TileDialogService extends BaseComponent implements OnDestroy {
    ref: DynamicDialogRef;
    dialogContentStyles = {
        width: '100%',
        height: '100%',
        padding: '0'
    };

    constructor(
        public dialogService: DialogService,
        private toastNotificationService: ToastNotificationService,
        private tileService: TileService,
        private spinnerService: SpinnerService
    ) {
        super();
    }

    showTopActiveIssuesCreateDialog(userProjects: Project[], dashboardId: number, dashboardTiles: Tile[]) {
        this.ref = this.dialogService.open(AddEditTopActiveIssuesTileComponent, {
            data: {
                isAddMode: true,
                userProjects,
                dashboardId
            },
            contentStyle: this.dialogContentStyles,
            closable: false,
            showHeader: false,
            modal: true,
            closeOnEscape: true,
        });

        this.ref.onClose.subscribe((newTile: NewTile) => {
            if (newTile) {
                this.addTile(newTile, dashboardTiles);
            }
        });
    }

    showTopActiveIssuesEditDialog(userProjects: Project[], tileToUpdate: Tile, applySettings: () => void) {
        this.ref = this.dialogService.open(AddEditTopActiveIssuesTileComponent, {
            data: {
                isAddMode: false,
                userProjects,
                tileToUpdate
            },
            contentStyle: this.dialogContentStyles,
            closable: false,
            showHeader: false,
            modal: true,
            closeOnEscape: true,
        });

        this.ref.onClose.subscribe((updatedTile: UpdateTile) => {
            if (updatedTile) {
                this.updateTile(updatedTile, tileToUpdate, applySettings);
            }
        });
    }

    ngOnDestroy() {
        if (this.ref) {
            this.ref.close();
        }
    }

    private addTile(newTile: NewTile, dashboardTiles: Tile[]) {
        this.spinnerService.show();
        this.tileService.addTile(newTile)
            .pipe(this.untilThis)
            .subscribe((response) => {
                if (response) {
                    this.spinnerService.hide();
                    dashboardTiles.push(response);
                    this.toastNotificationService.success('Tile has been added');
                }
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
                this.spinnerService.hide();
            });
    }

    private updateTile(updatedTile: UpdateTile, tileToUpdate: Tile, applySettings: () => void) {
        this.spinnerService.show();
        this.tileService.updateTile(updatedTile)
            .pipe(this.untilThis)
            .subscribe((response) => {
                if (response) {
                    this.spinnerService.hide();
                    Object.assign(tileToUpdate, updatedTile);
                    applySettings();
                    this.toastNotificationService.success('Tile has been updated');
                }
            }, error => {
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
                this.spinnerService.hide();
            });
    }
}
