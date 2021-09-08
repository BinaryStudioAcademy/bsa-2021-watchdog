import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@core/services/authentication.service';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CommomEditTileComponent } from '../../commom-edit-tile/commom-edit-tile.component';
import { TilesModalData } from '../../data/tiles-modal-data';

@Component({
    selector: 'app-add-edit-most-common-countries-tile',
    templateUrl: './add-edit-common-countries-tile.component.html',
    styleUrls: ['../../add-edit-modal-styles.sass'],
    providers: [TilesModalData]
})
export class AddEditMostCommonCountriesTileComponent extends CommomEditTileComponent implements OnInit {
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
        this.setTypeAndCategory(TileType.MostCommonCountries, TileCategory.List);
        super.ngOnInit();
    }

    addTileInit() {
        super.addTileInit();
        this.formGroup.controls.name.setValue('Most common countries');
    }
}
