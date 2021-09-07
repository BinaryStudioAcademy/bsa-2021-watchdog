import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { TileDialogService } from '@core/services/dialogs/tile-dialog.service';
import { ProjectService } from '@core/services/project.service';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { convertJsonToTileSettings } from '@core/utils/tile.utils';
import { CountryInfo } from '@shared/models/projects/country-info';
import { Project } from '@shared/models/projects/project';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { MostCommonCountriesSettings } from '@shared/models/tile/settings/most-common-countries-settings';
import { Tile } from '@shared/models/tile/tile';

@Component({
    selector: 'app-most-common-countries-tile',
    templateUrl: './most-common-countries-tile.component.html',
    styleUrls: ['./most-common-countries-tile.component.sass']
})
export class MostCommonCountriesTileComponent extends BaseComponent implements OnInit {
    @Input() project: Project;
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
    paginatorRows: number = 5;
    tileSettings: MostCommonCountriesSettings;
    countryInfos: CountryInfo[];
    requiredProjects = [];
    constructor(
        private projectsService: ProjectService,
        private toastNotification: ToastNotificationService,
        private tileDialogService: TileDialogService
    ) {
        super();
    }

    ngOnInit(): void {
        this.applySettings();
    }

    private applySettings(): void {
        this.countryInfos = [];
        this.getTileSettings();
        this.applyProjectSettings();
        this.requiredProjects.forEach(proj => {
            this.initCountryInfos(proj);
        });
    }

    initCountryInfos(project: Project): void {
        this.projectsService
            .getCountriesInfo(project.id)
            .pipe(this.untilThis)
            .subscribe(countryInfos => {
                countryInfos.forEach(countryInfo => {
                    this.addItem(countryInfo);
                });
                this.countryInfos = [...this.countryInfos];
            }, error => {
                this.toastNotification.error(error);
            });
    }

    addItem(searchingCountryInfo: CountryInfo): void {
        const tempCountryInfo: CountryInfo = this.countryInfos.find(countryInfo => countryInfo.country === searchingCountryInfo.country);
        if (tempCountryInfo) {
            tempCountryInfo.count += searchingCountryInfo.count;
        } else {
            this.countryInfos.push(searchingCountryInfo);
        }
    }

    editTile(): void {
        this.tileDialogService.showMostCommonCountriesEditDialog(this.userProjects, this.tile,
            () => this.applySettings());
    }

    private getTileSettings(): void {
        this.tileSettings = convertJsonToTileSettings(this.tile.settings, TileType.MostCommonCountries) as MostCommonCountriesSettings;
    }

    private applyProjectSettings(): void {
        this.requiredProjects = this.userProjects.filter(proj => this.tileSettings.sourceProjects.some(id => id === proj.id));
    }

    setTileDragStatus(status: boolean): void {
        this.dragTile.emit(status);
    }
}