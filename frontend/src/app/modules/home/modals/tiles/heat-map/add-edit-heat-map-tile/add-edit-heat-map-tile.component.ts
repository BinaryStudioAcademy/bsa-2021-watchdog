import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { TileService } from '@core/services/tile.service';
import { convertJsonToTileSettings, convertTileSettingsToJson } from '@core/utils/tile.utils';
import { regexs } from '@shared/constants/regexs';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { Project } from '@shared/models/projects/project';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { NewTile } from '@shared/models/tile/new-tile';
import { HeatMapSettings } from '@shared/models/tile/settings/heat-map.settings';
import { Tile } from '@shared/models/tile/tile';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TilesModalData } from '../../data/tiles-modal-data';
import { DateRangeDropdown } from '../../models/date-range-dropdown';
import { GranularityDropdown } from '../../models/granularity-dropdown';
import { IssueStatusCheckbox } from '../../models/issue-status-checkbox';

@Component({
  selector: 'app-add-edit-heat-map-tile',
  templateUrl: './add-edit-heat-map-tile.component.html',
  styleUrls: ['../../add-edit-modal-styles.sass'],
  providers: [TilesModalData],
})
export class AddEditHeatMapTileComponent implements OnInit {
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
        private tileService: TileService,
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
        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.HeatMap) as HeatMapSettings;
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
                'Heat map tile',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.tileName),
                ]
            ),
            dateRange: new FormControl(
                TileDateRangeType.ThePastWeek,
                [
                    Validators.required,
                ]
            ),
            granularity: new FormControl(
                TileGranularityType.OneDay,
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
        this.dateRangeDropdown = this.tileModalData.dateRangeHeatMapDropdownItems;
    }

    private updateGranularityDropdown(type: TileDateRangeType): void {
        this.granularityDropdown = this.tileModalData.dateRangeHeatMapGranularityMap[type];
    }

    private initIssueStatusCheckboxes(): void {
        this.issueStatusCheckboxes = this.tileModalData.issueStatusCheckboxes;
    }

    private addTile(values: any): void {
        const newTile: NewTile = {
            name: values.name,
            category: TileCategory.Chart,
            type: TileType.HeatMap,
            createdBy: this.authenticationService.getUser().id,
            dashboardId: this.currentDashboardId,
            settings: convertTileSettingsToJson(<HeatMapSettings>{
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
            settings: convertTileSettingsToJson(<HeatMapSettings>{
                dateRange: values.dateRange,
                granularity: values.granularity,
                issueStatuses: values.issueStatuses,
                sourceProjects: values.sourceProjects,
            })
        };
        this.close(updatedTile);
    }

}
