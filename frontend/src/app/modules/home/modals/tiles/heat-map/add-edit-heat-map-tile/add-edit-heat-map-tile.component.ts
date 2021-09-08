import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { convertJsonToTileSettings } from '@core/utils/tile.utils';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { HeatMapSettings } from '@shared/models/tile/settings/heat-map.settings';
import { Tile } from '@shared/models/tile/tile';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CommomEditTileComponent } from '../../commom-edit-tile/commom-edit-tile.component';
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
export class AddEditHeatMapTileComponent extends CommomEditTileComponent implements OnInit {
    dateRangeDropdown: DateRangeDropdown[];
    granularityDropdown: GranularityDropdown[];
    issueStatusCheckboxes: IssueStatusCheckbox[];

    headerTitle: string;
    submitButtonText: string;
    tileToEdit: Tile;

    constructor(
        public ref: DynamicDialogRef,
        public tileModalData: TilesModalData,
        public dialogConfig: DynamicDialogConfig,
        public authenticationService: AuthenticationService,
    ) {
        super(
            ref,
            tileModalData,
            dialogConfig,
            authenticationService
        );
    }

    ngOnInit() {
        super.ngOnInit();
        this.setTypeAndCategory(TileType.HeatMap, TileCategory.Chart);
        this.initDateRangeDropdown();
        this.initIssueStatusCheckboxes();
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

    editTileInit() {
        super.editTileInit();
        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.HeatMap) as HeatMapSettings;
        this.updateGranularityDropdown(tileSettings.dateRange);
        this.formGroup.addControl('dateRange', new FormControl(
            tileSettings.dateRange, [Validators.required]
        ));
        this.formGroup.addControl('granularity', new FormControl(
            tileSettings.granularity, [Validators.required]
        ));
        this.formGroup.addControl('issueStatuses', new FormControl(
            tileSettings.issueStatuses, [Validators.required]
        ));
    }

    addTileInit() {
        super.addTileInit();
        this.formGroup.controls.name.setValue('Heat map tile');
        this.currentDashboardId = this.dialogConfig.data.dashboardId;
        this.headerTitle = 'Create a tile';
        this.submitButtonText = 'Create';

        this.updateGranularityDropdown(this.dateRangeDropdown[1].type);
        this.formGroup.addControl('dateRange', new FormControl(
            TileDateRangeType.ThePastWeek, [Validators.required]
        ));
        this.formGroup.addControl('granularity', new FormControl(
            TileGranularityType.OneDay, [Validators.required]
        ));
        this.formGroup.addControl('issueStatuses', new FormControl(
            [IssueStatus.Active], [Validators.required]
        ));
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
}
