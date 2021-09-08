import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AuthenticationService } from '@core/services/authentication.service';
import { convertJsonToTileSettings } from '@core/utils/tile.utils';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TilesModalData } from '@modules/home/modals/tiles/data/tiles-modal-data';
import { DateRangeDropdown } from '@modules/home/modals/tiles/models/date-range-dropdown';
import { IssuesPerTimeSettings } from '@shared/models/tile/settings/issues-per-time-settings';
import { GranularityDropdown } from '@modules/home/modals/tiles/models/granularity-dropdown';
import { IssueStatusCheckbox } from '@modules/home/modals/tiles/models/issue-status-checkbox';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { CommomEditTileComponent } from '../../commom-edit-tile/commom-edit-tile.component';

@Component({
    selector: 'app-add-edit-issues-per-time-tile',
    templateUrl: './add-edit-issues-per-time-tile.component.html',
    styleUrls: ['../../add-edit-modal-styles.sass'],
    providers: [TilesModalData],
})
export class AddEditIssuesPerTimeTileComponent extends CommomEditTileComponent implements OnInit {
    dateRangeDropdown: DateRangeDropdown[];
    granularityDropdown: GranularityDropdown[];
    issueStatusCheckboxes: IssueStatusCheckbox[];

    constructor(
        public ref: DynamicDialogRef,
        public tileModalData: TilesModalData,
        public dialogConfig: DynamicDialogConfig,
        public authenticationService: AuthenticationService,
    ) {
        super(ref,
            tileModalData,
            dialogConfig,
            authenticationService);
    }

    ngOnInit() {
        this.setTypeAndCategory(TileType.IssuesPerTime, TileCategory.Chart);
        this.initDateRangeDropdown();
        this.initIssueStatusCheckboxes();
        super.ngOnInit();
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

        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.IssuesPerTime) as IssuesPerTimeSettings;
        this.updateGranularityDropdown(tileSettings.dateRange);
        this.formGroup.addControl('dateRange', new FormControl(
            tileSettings.dateRange,
            [Validators.required]
        ));
        this.formGroup.addControl('granularity', new FormControl(
            tileSettings.granularity,
            [Validators.required]
        ));
        this.formGroup.addControl('issueStatuses', new FormControl(
            tileSettings.issueStatuses,
            [Validators.required]
        ));
    }

    addTileInit() {
        super.addTileInit();
        this.updateGranularityDropdown(this.dateRangeDropdown[1].type);
        this.formGroup.controls.name.setValue('Issues per time tile');
        this.formGroup.addControl('dateRange', new FormControl(
            TileDateRangeType.ThePastDay,
            [Validators.required]
        ));
        this.formGroup.addControl('granularity', new FormControl(
            TileGranularityType.OneHour,
            [Validators.required]
        ));
        this.formGroup.addControl('issueStatuses', new FormControl(
            [IssueStatus.Active],
            [Validators.required]
        ));
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
}
