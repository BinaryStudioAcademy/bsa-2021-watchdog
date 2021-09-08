import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { BaseComponent } from '@core/components/base/base.component';
import { Project } from '@shared/models/projects/project';
import { Tile } from '@shared/models/tile/tile';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-base-tile',
    template: ''
})
export abstract class BaseTileComponent extends BaseComponent implements OnInit {
    @Input() tile: Tile;
    @Input() isShownEditTileMenu: boolean = false;
    @Input() userProjects: Project[] = [];
    @Input() resize: Observable<void>;
    @Input() events: Observable<void>;
    @Output() isDeleting: EventEmitter<Tile> = new EventEmitter<Tile>();
    @Output() isEditing: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() dragTile: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() changeTile: EventEmitter<void> = new EventEmitter<void>();

    @ViewChild('toExport') toExport: ElementRef;
    ngOnInit(): void {
        this.events
            .pipe(this.untilThis)
            .subscribe(() => this.editTile());
    }

    setTileDragStatus(status: boolean) {
        this.dragTile.emit(status);
    }

    abstract editTile(): void;
}
