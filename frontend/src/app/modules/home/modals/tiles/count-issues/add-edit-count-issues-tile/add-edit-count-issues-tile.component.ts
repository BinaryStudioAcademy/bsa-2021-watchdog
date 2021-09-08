import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AuthenticationService } from '@core/services/authentication.service';
import { convertJsonToTileSettings } from '@core/utils/tile.utils';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TilesModalData } from '@modules/home/modals/tiles/data/tiles-modal-data';
import { DateRangeDropdown } from '@modules/home/modals/tiles/models/date-range-dropdown';
import { IssueStatusCheckbox } from '@modules/home/modals/tiles/models/issue-status-checkbox';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { CountIssuesSettings } from '@shared/models/tile/settings/count-issues-settings';
import { CommomEditTileComponent } from '../../commom-edit-tile/commom-edit-tile.component';

@Component({
    selector: 'app-add-edit-count-issues-tile',
    templateUrl: './add-edit-count-issues-tile.component.html',
    styleUrls: ['../../add-edit-modal-styles.sass'],
    providers: [TilesModalData],
})
export class AddEditCountIssuesTileComponent extends CommomEditTileComponent implements OnInit {
    dateRangeDropdown: DateRangeDropdown[];
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
        super.ngOnInit();
        this.setTypeAndCategory(TileType.IssuesCount, TileCategory.Chart);
        this.initIssueStatusCheckboxes();
        this.initDateRangeDropdown();
    }

    addTileInit() {
        super.addTileInit();
        this.formGroup.controls.name.setValue('Issues count');
        this.formGroup.addControl('issueStatuses', new FormControl(
            [IssueStatus.Active], [Validators.required]
        ));
        this.formGroup.addControl('dateRange', new FormControl(
            TileDateRangeType.All, [Validators.required]
        ));
    }

    editTileInit() {
        super.editTileInit();
        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.IssuesCount) as CountIssuesSettings;
        this.formGroup.addControl('issueStatuses', new FormControl(
            tileSettings.issueStatuses, [Validators.required]
        ));
        this.formGroup.addControl('dateRange', new FormControl(
            tileSettings.dateRange, [Validators.required]
        ));
    }

    private initDateRangeDropdown(): void {
        this.dateRangeDropdown = this.tileModalData.dateRangeIssuesCountDropdownItems;
    }

    private initIssueStatusCheckboxes(): void {
        this.issueStatusCheckboxes = this.tileModalData.issueStatusCheckboxes;
    }

    get issueStatuses() { return this.formGroup.controls.issueStatuses; }
}
