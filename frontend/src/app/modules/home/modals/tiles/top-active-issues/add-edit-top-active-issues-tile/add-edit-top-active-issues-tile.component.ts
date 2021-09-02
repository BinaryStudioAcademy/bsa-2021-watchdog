import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Project } from '@shared/models/projects/project';
import { NewTile } from '@shared/models/tile/new-tile';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileService } from '@core/services/tile.service';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { Tile } from '@shared/models/tile/tile';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AuthenticationService } from '@core/services/authentication.service';
import { regexs } from '@shared/constants/regexs';
import { convertJsonToTileSettings, convertTileSettingsToJson } from '@core/utils/tile.utils';
import { TilesModalData } from '@modules/home/modals/tiles/data/tiles-modal-data';
import { DateRangeDropdown } from '@modules/home/modals/tiles/models/date-range-dropdown';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileSizeDropdown } from '@shared/models/tile/tile-size-dropdown';

@Component({
    selector: 'app-add-edit-top-active-issues-tile',
    templateUrl: './add-edit-top-active-issues-tile.component.html',
    styleUrls: ['../../add-edit-modal-styles.sass'],
    providers: [TilesModalData]
})
export class AddEditTopActiveIssuesTileComponent implements OnInit {
    formGroup: FormGroup;
    dateRangeDropdown: DateRangeDropdown[];
    tileSizeDropdown: TileSizeDropdown[];
    headerTitle: string;
    submitButtonText: string;
    currentDashboardId: number;
    tileToEdit: Tile;
    isAddMode: boolean;
    userProjects: Project[];

    constructor(
        private toastNotificationService: ToastNotificationService,
        private tileService: TileService,
        private ref: DynamicDialogRef,
        private dialogConfig: DynamicDialogConfig,
        private authenticationService: AuthenticationService,
        private tileModalData: TilesModalData
    ) {
    }

    ngOnInit() {
        this.isAddMode = this.dialogConfig.data.isAddMode;
        this.userProjects = this.dialogConfig.data.userProjects;

        this.initDateRangeDropdown();
        this.initTileSizeDropdown();

        switch (this.isAddMode) {
            case true:
                this.addTileInit();
                break;
            case false:
                this.editTileInit();
                break;
            default:
                console.error(`Bad Modal Mode - '${this.isAddMode}'`);
                this.close();
        }
    }

    close(tile?: any) {
        this.ref.close(tile);
    }

    submit(): void {
        const values = this.formGroup.value;
        if (this.isAddMode) {
            this.addTile(values);
        } else {
            this.editTile(values);
        }
    }

    private editTileInit() {
        this.tileToEdit = this.dialogConfig.data.tileToUpdate;
        this.headerTitle = `Editing tile ${this.tileToEdit.name}`;
        this.submitButtonText = 'Update';

        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.TopActiveIssues) as TopActiveIssuesSettings;
        this.formGroup = new FormGroup({
            sourceProjects: new FormControl(
                tileSettings.sourceProjects,
                [
                    Validators.required
                ]
            ),
            name: new FormControl(
                this.tileToEdit.name,
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.tileName)
                ]
            ),
            dateRange: new FormControl(
                tileSettings.dateRange,
                [
                    Validators.required
                ]
            ),
            issuesCount: new FormControl(
                tileSettings.issuesCount,
                [
                    Validators.required,
                    Validators.min(1),
                    Validators.max(1000)
                ]
            ),
            tileSize: new FormControl(
                tileSettings.tileSize,
                [
                    Validators.required
                ]
            )
        });
    }

    private addTileInit() {
        this.currentDashboardId = this.dialogConfig.data.dashboardId;
        this.headerTitle = 'Create a tile';
        this.submitButtonText = 'Create';

        this.formGroup = new FormGroup({
            sourceProjects: new FormControl(
                [],
                [
                    Validators.required
                ]
            ),
            name: new FormControl(
                'Top active issues tile',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.tileName)
                ]
            ),
            dateRange: new FormControl(
                TileDateRangeType.ThePastDay,
                [
                    Validators.required
                ]
            ),
            issuesCount: new FormControl(
                5,
                [
                    Validators.required,
                    Validators.min(1),
                    Validators.max(1000)
                ]
            ),
            tileSize: new FormControl(
                TileSizeType.Medium,
                [
                    Validators.required
                ]
            )
        });
    }

    private initDateRangeDropdown(): void {
        this.dateRangeDropdown = this.tileModalData.dateRangeDropdownItems;
    }

    private initTileSizeDropdown(): void {
        this.tileSizeDropdown = this.tileModalData.tileSizeDropdownItems;
    }

    private addTile(values: any): void {
        const newTile: NewTile = {
            name: values.name,
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            createdBy: this.authenticationService.getUser().id,
            dashboardId: this.currentDashboardId,
            settings: convertTileSettingsToJson(<TopActiveIssuesSettings>{
                issuesCount: values.issuesCount,
                sourceProjects: values.sourceProjects,
                dateRange: values.dateRange,
                tileSize: values.tileSize
            })
        };
        this.close(newTile);
    }

    private editTile(values: any): void {
        const updatedTile: UpdateTile = {
            id: this.tileToEdit.id,
            name: values.name,
            settings: convertTileSettingsToJson(<TopActiveIssuesSettings>{
                issuesCount: values.issuesCount,
                sourceProjects: values.sourceProjects,
                dateRange: values.dateRange,
                tileSize: values.tileSize
            })
        };
        this.close(updatedTile);
    }
}
