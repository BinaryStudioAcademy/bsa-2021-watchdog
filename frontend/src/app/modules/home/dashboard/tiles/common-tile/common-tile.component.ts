import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { TileType } from '@shared/models/tile/enums/tile-type';
import { Tile } from '@shared/models/tile/tile';
import { Observable, Subject } from 'rxjs';

@Component({
    selector: 'app-common-tile[tile][isShownEditTileMenu][userProjects]',
    templateUrl: './common-tile.component.html',
    styleUrls: ['./common-tile.component.sass']
})
export class CommonTileComponent {
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Input() resize: Observable<void>;
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();
    @Output() isEditing: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() changeTile: EventEmitter<void> = new EventEmitter<void>();

    tileTypes = TileType;
    edit: Subject<void> = new Subject<void>();


    emitEventToChild() {
        this.edit.next();
    }

    setTileDragStatus(status: boolean) {
        this.dragTile.emit(status);
    }

    changeTileFunc() {
        this.changeTile.emit();
    }
}
