import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { TopActiveTileSettings } from '@shared/models/tile/settings/top-active-tile-settings';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AuthenticationService } from '@core/services/authentication.service';
import { convertJsonToTileSettings } from '@core/utils/tile.utils';
import { TilesModalData } from '@modules/home/modals/tiles/data/tiles-modal-data';
import { DateRangeDropdown } from '@modules/home/modals/tiles/models/date-range-dropdown';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileSizeDropdown } from '@shared/models/tile/tile-size-dropdown';
import { CommomEditTileComponent } from '../../commom-edit-tile/commom-edit-tile.component';

@Component({
    selector: 'app-add-edit-top-active-issues-tile',
    templateUrl: './add-edit-top-active-issues-tile.component.html',
    styleUrls: ['../../add-edit-modal-styles.sass'],
    providers: [TilesModalData]
})
export class AddEditTopActiveIssuesTileComponent extends CommomEditTileComponent implements OnInit {
    dateRangeDropdown: DateRangeDropdown[];
    tileSizeDropdown: TileSizeDropdown[];

    constructor(
        public ref: DynamicDialogRef,
        public dialogConfig: DynamicDialogConfig,
        public authenticationService: AuthenticationService,
        public tileModalData: TilesModalData
    ) {
        super(ref,
            tileModalData,
            dialogConfig,
            authenticationService);
    }
    ngOnInit() {
        this.initDateRangeDropdown();
        this.setTypeAndCategory(TileType.TopActiveIssues, TileCategory.List);
        super.ngOnInit();
    }

    editTileInit() {
        super.editTileInit();

        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.TopActiveIssues) as TopActiveTileSettings;
        this.formGroup.addControl('dateRange', new FormControl(
            tileSettings.dateRange,
            [Validators.required]
        ));
        this.formGroup.addControl('issuesCount', new FormControl(
            tileSettings.itemsCount,
            [
                Validators.required,
                Validators.min(1),
                Validators.max(1000)
            ]
        ));
    }

    addTileInit() {
        super.addTileInit();
        this.formGroup.controls.name.setValue('Top active issues tile');
        this.formGroup.addControl('dateRange', new FormControl(
            TileDateRangeType.ThePastDay,
            [Validators.required]
        ));
        this.formGroup.addControl('issuesCount', new FormControl(
            5,
            [
                Validators.required,
                Validators.min(1),
                Validators.max(1000)
            ]
        ));
    }

    private initDateRangeDropdown(): void {
        this.dateRangeDropdown = this.tileModalData.dateRangeDropdownItems;
    }
}
