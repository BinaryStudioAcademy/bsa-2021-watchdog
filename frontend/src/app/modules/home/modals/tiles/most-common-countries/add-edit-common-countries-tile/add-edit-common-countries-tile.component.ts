import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { convertJsonToTileSettings, convertTileSettingsToJson } from '@core/utils/tile.utils';
import { regexs } from '@shared/constants/regexs';
import { Project } from '@shared/models/projects/project';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { NewTile } from '@shared/models/tile/new-tile';
import { MostCommonCountriesSettings } from '@shared/models/tile/settings/most-common-countries-settings';
import { Tile } from '@shared/models/tile/tile';
import { TileSizeDropdown } from '@shared/models/tile/tile-size-dropdown';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TilesModalData } from '../../data/tiles-modal-data';

@Component({
    selector: 'app-add-edit-most-common-countries-tile',
    templateUrl: './add-edit-common-countries-tile.component.html',
    styleUrls: ['../../add-edit-modal-styles.sass'],
    providers: [TilesModalData]
})
export class AddEditMostCommonCountriesTileComponent implements OnInit {
    formGroup: FormGroup;
    tileSizeDropdown: TileSizeDropdown[];
    headerTitle: string;
    submitButtonText: string;
    currentDashboardId: number;
    tileToEdit: Tile;
    isAddMode: boolean;
    userProjects: Project[];

    constructor(
        private ref: DynamicDialogRef,
        private dialogConfig: DynamicDialogConfig,
        private authenticationService: AuthenticationService,
        private tileModalData: TilesModalData
    ) {
    }

    ngOnInit() {
        this.isAddMode = this.dialogConfig.data.isAddMode;
        this.userProjects = this.dialogConfig.data.userProjects;

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

        const tileSettings = convertJsonToTileSettings(
            this.tileToEdit.settings, TileType.MostCommonCountries
        ) as MostCommonCountriesSettings;
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
                'Most common countries',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.tileName)
                ]
            ),
            tileSize: new FormControl(
                TileSizeType.Small,
                [
                    Validators.required
                ]
            )
        });
    }

    private initTileSizeDropdown(): void {
        this.tileSizeDropdown = this.tileModalData.tileSizeDropdownItems;
    }

    private addTile(values: any): void {
        const newTile: NewTile = {
            name: values.name,
            category: TileCategory.List,
            type: TileType.MostCommonCountries,
            createdBy: this.authenticationService.getUser().id,
            dashboardId: this.currentDashboardId,
            settings: convertTileSettingsToJson(<MostCommonCountriesSettings>{
                sourceProjects: values.sourceProjects,
                tileSize: values.tileSize
            })
        };
        this.close(newTile);
    }

    private editTile(values: any): void {
        const updatedTile: UpdateTile = {
            id: this.tileToEdit.id,
            name: values.name,
            settings: convertTileSettingsToJson(<MostCommonCountriesSettings>{
                sourceProjects: values.sourceProjects,
                tileSize: values.tileSize
            })
        };
        this.close(updatedTile);
    }
}
