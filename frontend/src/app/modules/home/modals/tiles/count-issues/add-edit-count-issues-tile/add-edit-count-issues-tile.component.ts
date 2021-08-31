import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Tile } from '@shared/models/tile/tile';
import { Project } from '@shared/models/projects/project';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AuthenticationService } from '@core/services/authentication.service';
import { convertJsonToTileSettings, convertTileSettingsToJson } from '@core/utils/tile.utils';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { regexs } from '@shared/constants/regexs';
import { NewTile } from '@shared/models/tile/new-tile';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { TilesModalData } from '@modules/home/modals/tiles/data/tiles-modal-data';
import { DateRangeDropdown } from '@modules/home/modals/tiles/models/date-range-dropdown';
import { IssueStatusCheckbox } from '@modules/home/modals/tiles/models/issue-status-checkbox';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { CountIssuesSettings } from '@shared/models/tile/settings/count-issues-settings';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';

@Component({
    selector: 'app-add-edit-count-issues-tile',
    templateUrl: './add-edit-count-issues-tile.component.html',
    styleUrls: ['./add-edit-count-issues-tile.component.sass'],
    providers: [TilesModalData],
})
export class AddEditCountIssuesTileComponent implements OnInit {
    userProjects: Project[];
    tileToEdit: Tile;
    isAddMode: boolean;
    currentDashboardId: number;

    formGroup: FormGroup;
    dateRangeDropdown: DateRangeDropdown[];
    issueStatusCheckboxes: IssueStatusCheckbox[];
    public tileSizeDropdown: TileSizeDropdown[];

    headerTitle: string;
    submitButtonText: string;

    constructor(
        private ref: DynamicDialogRef,
        private tileModalData: TilesModalData,
        private dialogConfig: DynamicDialogConfig,
        private authenticationService: AuthenticationService,
    ) {
    }

    ngOnInit() {
        this.isAddMode = this.dialogConfig.data.isAddMode;
        this.userProjects = this.dialogConfig.data.userProjects;

        this.initDateRangeDropdown();
        this.initIssueStatusCheckboxes();
        this.initTileSizeDropdown();

        switch (this.isAddMode) {
            case false:
                this.editTileInit();
                break;
            case true:
                this.addTileInit();
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

        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.IssuesCount) as CountIssuesSettings;
        this.formGroup = new FormGroup({
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
            issueStatuses: new FormControl(
                [IssueStatus.Active],
                [
                    Validators.required,
                ]
            ),
            sourceProjects: new FormControl(
                tileSettings.sourceProjects,
                [
                    Validators.required
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
            name: new FormControl(
                'Issues count',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.tileName),
                ]
            ),
            dateRange: new FormControl(
                TileDateRangeType.ThePastDay,
                [
                    Validators.required,
                ]
            ),
            issueStatuses: new FormControl(
                [IssueStatus.Active],
                [
                    Validators.required,
                ]
            ),
            sourceProjects: new FormControl(
                [],
                [
                    Validators.required,
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

    private initIssueStatusCheckboxes(): void {
        this.issueStatusCheckboxes = this.tileModalData.issueStatusCheckboxes;
    }

    private addTile(values: any): void {
        const newTile: NewTile = {
            name: values.name,
            category: TileCategory.Chart,
            type: TileType.IssuesCount,
            createdBy: this.authenticationService.getUser().id,
            dashboardId: this.currentDashboardId,
            settings: convertTileSettingsToJson(<CountIssuesSettings>{
                dateRange: values.dateRange,
                issuesCount: values.issuesCount,
                sourceProjects: values.sourceProjects,
                issueStatuses: values.issueStatuses,
                tileSize: values.tileSize
            })
        };
        this.close(newTile);
    }

    private editTile(values: any): void {
        const updatedTile: UpdateTile = {
            id: this.tileToEdit.id,
            name: values.name,
            settings: convertTileSettingsToJson(<CountIssuesSettings>{
                dateRange: values.dateRange,
                issuesCount: values.issuesCount,
                sourceProjects: values.sourceProjects,
                issueStatuses: values.issueStatuses,
                tileSize: values.tileSize
            })
        };
        this.close(updatedTile);
    }

    private initTileSizeDropdown(): void {
        this.tileSizeDropdown = this.tileModalData.tileSizeDropdownItems;
    }
}

interface TileSizeDropdown {
    name: string,
    type: TileSizeType
}
