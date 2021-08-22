import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Tile } from '@shared/models/tile/tile';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TileService } from '@core/services/tile.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { regexs } from '@shared/constants/regexs';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { BaseComponent } from '@core/components/base/base.component';

@Component({
    selector: 'app-tile-header[tile][isShownEditTileMenu]',
    templateUrl: './tile-header.component.html',
    styleUrls: ['./tile-header.component.sass']
})
export class TileHeaderComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Output() isDeleting: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() isEditing: EventEmitter<boolean> = new EventEmitter<boolean>();

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
            message: `Are you sure you wish to delete the ${this.tile.name} tile?`,
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

    private resetFormGroup() {
        this.formGroup.reset();
        this.formGroup.patchValue({ name: this.tile.name });
    }
}
