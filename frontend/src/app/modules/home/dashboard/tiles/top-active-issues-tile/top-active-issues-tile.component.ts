import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { TopActiveIssuesSettings } from '@shared/models/tile/settings/top-active-issues-settings';
import { TileService } from '@core/services/tile.service';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Tile } from '@shared/models/tile/tile';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfirmWindowService } from '@core/services/confirm-window.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { regexs } from '@shared/constants/regexs';
import { BaseComponent } from '@core/components/base/base.component';
import { UpdateTile } from '@shared/models/tile/update-tile';
import { IssueMessage } from '@shared/models/issue/issue-message';
import { TopIssuesInfo } from '@shared/models/issue/top-issues.info';
import { IssueService } from '@core/services/issue.service';

@Component({
    selector: 'app-top-active-issues-tile[tile][isShownMenu]',
    templateUrl: './top-active-issues-tile.component.html',
    styleUrls: ['./top-active-issues-tile.component.sass']
})
export class TopActiveIssuesTileComponent extends BaseComponent implements OnInit {
    @Input() userProjects: Project[] = [];
    @Input() tile: Tile;
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();

    issuesInfo: TopIssuesInfo[] = [];
    displayedProjects: Project[];
    formGroup: FormGroup;
    isShownTileMenu: boolean;
    tileSettings: TopActiveIssuesSettings;
    isEditName: boolean = false;

    constructor(
        private tileService: TileService,
        private toastNotificationService: ToastNotificationService,
        private confirmWindowService: ConfirmWindowService,
        private tileDialogService: TileDialogService,
        private issuesService: IssueService
    ) {
        super();
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

    onIssueSelect(issue: IssueMessage) {
        console.log(issue);
        //TODO: redirect here to a page of selected Issue
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
                    this.tile = response as Tile;
                    this.resetFormGroup();
                    this.toastNotificationService.success('Name changed');
                }
            }, error => {
                this.resetFormGroup();
                this.toastNotificationService.error(`${error}`, 'Error', 2000);
            });
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

        this.issuesService
            .getTopIssues()
            .pipe(this.untilThis)
            .subscribe(issuesInfo => {
                this.issuesInfo = issuesInfo;
                this.issuesInfo.splice(this.tileSettings.issuesCount);
            }, error => {
                this.toastNotificationService.error(error, '', 1500);
            });
    }

    private resetFormGroup() {
        this.formGroup.reset();
        this.formGroup.patchValue({ name: this.tile.name });
    }
}
