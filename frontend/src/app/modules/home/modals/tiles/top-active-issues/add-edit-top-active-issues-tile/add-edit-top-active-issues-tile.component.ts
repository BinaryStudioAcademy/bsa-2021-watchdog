import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Project } from '@shared/models/projects/project';
import { NewTile } from '@shared/models/tile/new-tile';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileService } from '@core/services/tile.service';
import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { Tile } from '@shared/models/tile/tile';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AuthenticationService } from '@core/services/authentication.service';
import { regexs } from '@shared/constants/regexs';
import { convertJsonToTileSettings, convertTileSettingsToJson } from '@core/utils/tile.utils';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';

@Component({
    selector: 'app-add-edit-top-active-issues-tile',
    templateUrl: './add-edit-top-active-issues-tile.component.html',
    styleUrls: ['./add-edit-top-active-issues-tile.component.sass']
})
export class AddEditTopActiveIssuesTileComponent implements OnInit {
    public formGroup: FormGroup;
    public dateRangeDropdown: DateRangeDropdown[];
    public tileSizeDropdown: TileSizeDropdown[];
    public headerTitle: string;
    public submitButtonText: string;
    currentDashboardId: number;
    tileToEdit: Tile;
    isAddMode: boolean;
    userProjects: Project[];

    constructor(
        private toastNotificationService: ToastNotificationService,
        private tileService: TileService,
        public ref: DynamicDialogRef,
        public dialogConfig: DynamicDialogConfig,
        private authenticationService: AuthenticationService
    ) {
    }

    ngOnInit() {
        this.isAddMode = this.dialogConfig.data.isAddMode;
        this.userProjects = this.dialogConfig.data.userProjects;

        this.initDateRangeDropdown();
        this.initTileSizeDropdown();

        switch (this.isAddMode) {
            case false:
                this.tileToEdit = this.dialogConfig.data.tileToUpdate;
                this.editTileInit();
                break;
            case true:
                this.currentDashboardId = this.dialogConfig.data.dashboardId;
                this.addTileInit();
                break;
            default:
                console.log(`Bad Modal Mode - '${this.isAddMode}'`);
                this.close();
        }
    }

    close(tile?: any) {
        this.ref.close(tile);
    }

    submit(): void {
        if (this.formGroup.invalid) {
            this.toastNotificationService.error('One or more fields is not valid!');
        }
        const values = this.formGroup.value;
        if (this.isAddMode) {
            this.addTile(values);
        } else {
            this.editTile(values);
        }
    }

    private editTileInit() {
        this.headerTitle = `Editing tile ${this.tileToEdit.name}`;
        this.submitButtonText = 'Update';

        const tileSettings = convertJsonToTileSettings(this.tileToEdit.settings, TileType.TopActiveIssues);
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
            dateRange: new FormControl(
                tileSettings.dateRange,
                [
                    Validators.required
                ]
            ),
            issuesCount: new FormControl(
                tileSettings.issuesCount,
                [
                    Validators.required,
                    Validators.min(1),
                    Validators.max(1000)
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
        this.headerTitle = 'Create Top Active Issues tile';
        this.submitButtonText = 'Create';

        this.formGroup = new FormGroup({
            sourceProjects: new FormControl(
                [],
                [
                    Validators.required
                ]
            ),
            name: new FormControl(
                'Top active issues tile',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.tileName)
                ]
            ),
            dateRange: new FormControl(
                this.dateRangeDropdown[1].type,
                [
                    Validators.required
                ]
            ),
            issuesCount: new FormControl(
                5,
                [
                    Validators.required,
                    Validators.min(1),
                    Validators.max(1000)
                ]
            ),
            tileSize: new FormControl(
                this.tileSizeDropdown[0].type,
                [
                    Validators.required
                ]
            )
        });
    }

    private initDateRangeDropdown(): void {
        this.dateRangeDropdown = [{
            type: TileDateRangeType.ThePastHour,
            name: 'The Past Hour'
        },
        {
            type: TileDateRangeType.ThePastDay,
            name: 'The Past Day'
        },
        {
            type: TileDateRangeType.ThePast2Days,
            name: 'The Past 2 Days'
        },
        {
            type: TileDateRangeType.ThePastWeek,
            name: 'The Past Week'
        },
        {
            type: TileDateRangeType.ThePast2Weeks,
            name: 'The Past 2 Weeks'
        }];
    }

    private initTileSizeDropdown(): void {
        this.tileSizeDropdown = [
            {
                type: TileSizeType.Small,
                name: 'Small'
            },
            {
                type: TileSizeType.Medium,
                name: 'Medium'
            },
            {
                type: TileSizeType.Large,
                name: 'Large'
            }
        ];
    }

    private addTile(values: any): void {
        const newTile: NewTile = {
            name: values.name,
            category: TileCategory.List,
            type: TileType.TopActiveIssues,
            createdBy: this.authenticationService.getUser().id,
            dashboardId: this.currentDashboardId,
            settings: convertTileSettingsToJson(<TopActiveIssuesSettings>{
                issuesCount: values.issuesCount,
                sourceProjects: values.sourceProjects,
                dateRange: values.dateRange,
                tileSize: values.tileSize
            })
        };
        this.close(newTile);
    }

    private editTile(values: any): void {
        const updatedTile: UpdateTile = {
            id: this.tileToEdit.id,
            name: values.name,
            settings: convertTileSettingsToJson(<TopActiveIssuesSettings>{
                issuesCount: values.issuesCount,
                sourceProjects: values.sourceProjects,
                dateRange: values.dateRange,
                tileSize: values.tileSize
            })
        };
        this.close(updatedTile);
    }
}

interface DateRangeDropdown {
    name: string,
    type: TileDateRangeType
}

interface TileSizeDropdown {
    name: string,
    type: TileSizeType
}
