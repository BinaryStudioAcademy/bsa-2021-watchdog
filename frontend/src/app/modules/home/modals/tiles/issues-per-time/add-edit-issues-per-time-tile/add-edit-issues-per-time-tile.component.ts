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
import { IssuesPerTimeSettings } from '@shared/models/tile/settings/issues-per-time-settings';
import { GranularityDropdown } from '@modules/home/modals/tiles/models/granularity-dropdown';
import { IssueStatusCheckbox } from '@modules/home/modals/tiles/models/issue-status-checkbox';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';

@Component({
    selector: 'app-add-edit-issues-per-time-tile',
    templateUrl: './add-edit-issues-per-time-tile.component.html',
    styleUrls: ['../../add-edit-modal-styles.sass'],
    providers: [TilesModalData],
})
export class AddEditIssuesPerTimeTileComponent implements OnInit {
    userProjects: Project[];
    tileToEdit: Tile;
    isAddMode: boolean;
    currentDashboardId: number;

    formGroup: FormGroup;
    dateRangeDropdown: DateRangeDropdown[];
    granularityDropdown: GranularityDropdown[];
    issueStatusCheckboxes: IssueStatusCheckbox[];

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

    onSelectedDateRange(value: any) {
        this.updateGranularityDropdown(value);
        const currentValue = this.formGroup.controls.granularity.value;
        this.formGroup.controls.granularity.patchValue(
            this.granularityDropdown.some(val => val.type === currentValue)
                ? currentValue
                : this.granularityDropdown[0].type
        );
    }

    private editTileInit() {
        this.tileToEdit = this.dialogConfig.data.tileToUpdate;
        this.headerTitle = `Editing tile ${this.tileToEdit.name}`;
        this.submitButtonText = 'Update';

        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.IssuesPerTime) as IssuesPerTimeSettings;
        this.updateGranularityDropdown(tileSettings.dateRange);
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
            granularity: new FormControl(
                tileSettings.granularity,
                [
                    Validators.required
                ]
            ),
            issueStatuses: new FormControl(
                tileSettings.issueStatuses,
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
        });
    }

    private addTileInit() {
        this.currentDashboardId = this.dialogConfig.data.dashboardId;
        this.headerTitle = 'Create a tile';
        this.submitButtonText = 'Create';

        this.updateGranularityDropdown(this.dateRangeDropdown[1].type);
        this.formGroup = new FormGroup({
            name: new FormControl(
                'Issues per time tile',
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
            granularity: new FormControl(
                TileGranularityType.OneHour,
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
        });
    }

    private initDateRangeDropdown(): void {
        this.dateRangeDropdown = this.tileModalData.dateRangeDropdownItems;
    }

    private updateGranularityDropdown(type: TileDateRangeType): void {
        this.granularityDropdown = this.tileModalData.dateRangeGranularityMap[type];
    }

    private initIssueStatusCheckboxes(): void {
        this.issueStatusCheckboxes = this.tileModalData.issueStatusCheckboxes;
    }

    private addTile(values: any): void {
        const newTile: NewTile = {
            name: values.name,
            category: TileCategory.Chart,
            type: TileType.IssuesPerTime,
            createdBy: this.authenticationService.getUser().id,
            dashboardId: this.currentDashboardId,
            settings: convertTileSettingsToJson(<IssuesPerTimeSettings>{
                dateRange: values.dateRange,
                granularity: values.granularity,
                issueStatuses: values.issueStatuses,
                sourceProjects: values.sourceProjects,
            })
        };
        this.close(newTile);
    }

    private editTile(values: any): void {
        const updatedTile: UpdateTile = {
            id: this.tileToEdit.id,
            name: values.name,
            settings: convertTileSettingsToJson(<IssuesPerTimeSettings>{
                dateRange: values.dateRange,
                granularity: values.granularity,
                issueStatuses: values.issueStatuses,
                sourceProjects: values.sourceProjects,
            })
        };
        this.close(updatedTile);
    }
}
