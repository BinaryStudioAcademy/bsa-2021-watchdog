import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '@core/services/authentication.service';
import { convertTileSettingsToJson } from '@core/utils/tile.utils';
import { regexs } from '@shared/constants/regexs';
import { Project } from '@shared/models/projects/project';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { NewTile } from '@shared/models/tile/new-tile';
import { Tile } from '@shared/models/tile/tile';
import { TileSizeDropdown } from '@shared/models/tile/tile-size-dropdown';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TilesModalData } from '../data/tiles-modal-data';
import { DateRangeDropdown } from '../models/date-range-dropdown';

@Component({
    selector: 'app-commom-edit-tile',
    templateUrl: './commom-edit-tile.component.html',
    styleUrls: ['../add-edit-modal-styles.sass']
})
export class CommomEditTileComponent implements OnInit {
    userProjects: Project[];

    isAddMode: boolean;
    currentDashboardId: number;

    formGroup: FormGroup;
    dateRangeDropdown: DateRangeDropdown[];
    tileSizeDropdown: TileSizeDropdown[];

    headerTitle: string;
    submitButtonText: string;
    tileToEdit: Tile;

    private type: TileType;
    private category: TileCategory;

    @Output() submited = new EventEmitter<void>();
    @Input() form: FormGroup;
    constructor(
        public ref: DynamicDialogRef,
        public tileModalData: TilesModalData,
        public dialogConfig: DynamicDialogConfig,
        public authenticationService: AuthenticationService,
    ) {
    }
    ngOnInit(): void {
        if (this.form) {
            this.formGroup = this.form;
        }
        this.isAddMode = this.dialogConfig.data.isAddMode;
        this.userProjects = this.dialogConfig.data.userProjects;
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

    setTypeAndCategory(type: TileType, category: TileCategory) {
        this.type = type;
        this.category = category;
    }

    initTileSizeDropdown(): void {
        this.tileSizeDropdown = this.tileModalData.tileSizeDropdownItems;
    }

    editTileInit() {
        this.tileToEdit = this.dialogConfig.data.tileToUpdate;
        this.headerTitle = `Editing tile ${this.tileToEdit.name}`;
        this.submitButtonText = 'Update';

        const tileSettings = JSON.parse(this.tileToEdit.settings);
        if (!this.form) {
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
    }

    addTileInit() {
        this.currentDashboardId = this.dialogConfig.data.dashboardId;
        this.headerTitle = 'Create a tile';
        this.submitButtonText = 'Create';
        if (!this.form) {
            this.formGroup = new FormGroup({
                name: new FormControl(
                    '',
                    [
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(50),
                        Validators.pattern(regexs.tileName),
                    ]
                ),
                sourceProjects: new FormControl([], [Validators.required]),
                tileSize: new FormControl(TileSizeType.Medium, [Validators.required])
            });
        }
    }

    close(tile?: any) {
        this.ref.close(tile);
    }
    submit() {
        const values = this.formGroup.value;
        if (this.isAddMode) {
            this.addTile(values);
        } else {
            this.editTile(values);
        }
    }

    editTile(values: any): void {
        const { name, ...settings } = values;
        const updatedTile: UpdateTile = {
            id: this.tileToEdit.id,
            name,
            settings: convertTileSettingsToJson(settings)
        };
        this.close(updatedTile);
    }

    addTile(values: any): void {
        if (this.category === undefined || this.type === undefined) {
            throw new Error('category or type did not set');
        }
        const { name, ...settings } = values;
        const newTile: NewTile = {
            name,
            category: this.category,
            type: this.type,
            createdBy: this.authenticationService.getUserId(),
            dashboardId: this.currentDashboardId,
            settings: convertTileSettingsToJson(settings)
        };
        this.close(newTile);
    }

    get name() { return this.formGroup.controls.name; }
    get sourceProjects() { return this.formGroup.controls.sourceProjects; }
}
