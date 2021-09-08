import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Tile } from '@shared/models/tile/tile';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TileService } from '@core/services/tile.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { regexs } from '@shared/constants/regexs';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { BaseComponent } from '@core/components/base/base.component';
import { MenuItem } from 'primeng/api';
import { ExportType } from '@shared/models/tile/enums/export-type';

@Component({
    selector: 'app-tile-header[tile][isShownEditTileMenu]',
    templateUrl: './tile-header.component.html',
    styleUrls: ['./tile-header.component.sass']
})
export class TileHeaderComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Output() isDeleting: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() isEditing: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() isExporting: EventEmitter<ExportType> = new EventEmitter<ExportType>();
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
    menuTileExportItems: MenuItem[] = [];
    selectedItem?: MenuItem;

    formGroup: FormGroup;
    isShownTileMenu: boolean;
    isEditName: boolean = false;

    constructor(
        private tileService: TileService,
        private toastNotificationService: ToastNotificationService,
        private confirmWindowService: ConfirmWindowService,
    ) {
        super();
    }

    @Input() set isShownEditTileMenu(val: boolean) {
        if (val === false && this.isEditName === true) {
            this.resetFormGroup();
            this.isEditName = false;
        }
        this.isShownTileMenu = val;
    }

    ngOnInit(): void {
        this.initMenuExportTypesItems();
        this.formGroup = new FormGroup({
            name: new FormControl(
                this.tile.name,
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.tileName),
                ]
            )
        });
    }

    toggleNameEditor() {
        this.resetFormGroup();
        this.isEditName = !this.isEditName;
    }

    saveNameChanges() {
        this.isEditName = false;
        this.tile.name = this.formGroup.controls.name.value;
        this.tileService.updateTile(this.tile as UpdateTile)
            .pipe(this.untilThis)
            .subscribe((response) => {
                if (response) {
                    this.tile.name = response.name;
                    this.resetFormGroup();
                    this.toastNotificationService.success('Name changed');
                }
            }, error => {
                this.resetFormGroup();
                this.toastNotificationService.error(error);
            });
    }

    deleteTile() {
        this.confirmWindowService.confirm({
            title: 'Delete tile?',
            message: `Are you sure you wish to delete the <strong>${this.tile.name}</strong> tile?`,
            acceptButton: { class: 'p-button-primary p-button-outlined' },
            cancelButton: { class: 'p-button-secondary p-button-outlined' },
            accept: () => this.isDeleting.emit(true),
        });
    }

    editTile() {
        this.isEditName = false;
        this.resetFormGroup();
        this.isEditing.emit(true);
    }

    tileExportTypeSelected(item?: MenuItem): void {
        switch (+item.id) {
            case ExportType.Jpg:
                this.exportTile(+item.id);
                break;
            case ExportType.Png:
                this.exportTile(+item.id);
                break;
            case ExportType.Pdf:
                this.exportTile(+item.id);
                break;
            default:
                break;
        }
    }

    private initMenuExportTypesItems(): void {
        this.menuTileExportItems = [
            {
                id: ExportType.Jpg.toString(),
                label: 'Export in jpg',
                icon: 'pi pi-image',
                command: event => this.tileExportTypeSelected(event.item)
            },
            {
                id: ExportType.Png.toString(),
                label: 'Export in png',
                icon: 'pi pi-image',
                command: event => this.tileExportTypeSelected(event.item)
            },
            {
                id: ExportType.Pdf.toString(),
                label: 'Export in pdf',
                icon: 'pi pi-file',
                command: event => this.tileExportTypeSelected(event.item)
            },
        ];
    }

    exportTile(type: ExportType) {
        this.isExporting.emit(type);
    }

    dragOn() {
        this.dragTile.emit(true);
    }

    dragOff() {
        this.dragTile.emit(false);
    }

    private resetFormGroup() {
        this.formGroup.reset();
        this.formGroup.patchValue({ name: this.tile.name });
    }
}
