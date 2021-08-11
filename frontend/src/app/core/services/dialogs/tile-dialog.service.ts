import { Injectable, OnDestroy } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AddEditTopActiveIssuesTileComponent } from '@modules/home/modals/tiles/top-active-issues/add-edit-top-active-issues-tile/add-edit-top-active-issues-tile.component';
import { Project } from '@shared/models/projects/project';
import { Tile } from '@shared/models/tile/tile';
import { NewTile } from '@shared/models/tile/new-tile';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { UpdateTile } from '@shared/models/tile/update-tile';

@Injectable({
    providedIn: 'root'
})
export class TileDialogService implements OnDestroy {
    ref: DynamicDialogRef;
    dialogContentStyles = {
        width: '100%',
        height: '100%',
        padding: '0'
    };

    constructor(
        public dialogService: DialogService,
        private toastNotificationService: ToastNotificationService
    ) {
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
                //TODO: create real tile
                dashboardTiles.push(newTile as Tile);
                this.toastNotificationService.success('Tile Created');
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
                //TODO: update real tile
                Object.assign(tileToUpdate, updatedTile);
                applySettings();
                this.toastNotificationService.success('Updated');
            }
        });
    }

    ngOnDestroy() {
        if (this.ref) {
            this.ref.close();
        }
    }
}
