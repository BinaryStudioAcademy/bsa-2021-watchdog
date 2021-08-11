import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { Issue } from '@shared/models/issue/issue';
import { TopActiveIssuesSettings } from '@shared/models/tile/tiles-settings/top-active-issues-settings';
import { TileService } from '@core/services/tile.service';
import { TileType } from '@shared/models/tile/tile-type';
import { Tile } from '@shared/models/tile/tile';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { regexs } from '@shared/constants/regexs';

@Component({
    selector: 'app-top-active-issues-tile[tile][isShownMenu]',
    templateUrl: './top-active-issues-tile.component.html',
    styleUrls: ['./top-active-issues-tile.component.sass']
})
export class TopActiveIssuesTileComponent implements OnInit {
    @Input() issues: Issue[] = [];
    @Input() userProjects: Project[] = [];
    @Input() tile: Tile;
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();

    displayedIssues: Issue[];
    displayedProjects: Project[];
    formGroup: FormGroup;
    isShownTileMenu: boolean;
    tileSettings: TopActiveIssuesSettings;
    isEditName: boolean = false;

    constructor(
        private tileService: TileService,
        private toastNotificationService: ToastNotificationService,
        private confirmWindowService: ConfirmWindowService,
        private tileDialogService: TileDialogService
    ) {
    }

    @Input() set isShownMenu(val: boolean) {
        if (val === false && this.isEditName === true) {
            this.resetFormGroup();
            this.isEditName = false;
        }
        this.isShownTileMenu = val;
    }

    ngOnInit(): void {
        this.applySettings();
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

    onIssueSelect(issue: Issue) {
        console.log(issue);
        //TODO: redirect here to a page of selected Issue
    }

    toggleNameEditor() {
        this.resetFormGroup();
        this.isEditName = !this.isEditName;
    }

    saveNameChanges() {
        this.tile.name = this.formGroup.controls.name.value;
        this.toggleNameEditor();
        this.toastNotificationService.success('Name changed');
        this.toastNotificationService.specificNotification({});
        //TODO: update name
    }

    deleteTile() {
        this.confirmWindowService.confirm({
            title: 'Delete tile?',
            message: `Are you sure you wish to delete the ${this.tile.name} tile?`,
            acceptButton: { class: 'p-button-primary p-button-outlined' },
            cancelButton: { class: 'p-button-secondary p-button-outlined' },
            accept: () => this.isDeleting.emit(this.tile),
        });
    }

    editTile() {
        this.isEditName = false;
        this.resetFormGroup();
        this.tileDialogService.showTopActiveIssuesEditDialog(this.userProjects, this.tile, () => this.applySettings());
    }

    private applySettings() {
        this.tileSettings = this.tileService.convertJsonToTileSettings(this.tile.settings, TileType.TopActiveIssues);
        // get only required projects
        this.displayedProjects = [...this.userProjects.filter(proj => {
            for (let i = 0; i < this.tileSettings.sourceProjects.length; i += 1) {
                if (this.tileSettings.sourceProjects[i] === proj.id) {
                    return true;
                }
            }
            return false;
        })];
        this.displayedIssues = [...this.issues];
        //TODO: filter issues by required projects and display them on the table
        this.displayedIssues.sort((a, b) => b.events - a.events);
        this.displayedIssues.splice(this.tileSettings.issuesCount);
    }

    private resetFormGroup() {
        this.formGroup.reset();
        this.formGroup.patchValue({ name: this.tile.name });
    }
}
