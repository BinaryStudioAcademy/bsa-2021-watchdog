import { TileWithOrder } from '@shared/models/tile/tile-with-order';
import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { Observable } from 'rxjs';
import { Tile } from '@shared/models/tile/tile';
import { NewTile } from '@shared/models/tile/new-tile';
import { UpdateTile } from '@shared/models/tile/update-tile';

@Injectable({ providedIn: 'root' })
export class TileService {
    readonly routePrefix = '/tiles';

    constructor(private httpService: CoreHttpService) {
    }

    get(id: number): Observable<Tile> {
        return this.httpService.getRequest<Tile>(`${this.routePrefix}/${id}`);
    }

    addTile(newTile: NewTile): Observable<Tile> {
        return this.httpService.postRequest<Tile>(`${this.routePrefix}`, newTile);
    }

    deleteTile(tileId: number) {
        return this.httpService.deleteRequest<number>(`${this.routePrefix}/${tileId}`);
    }

    updateTile(updateTile: UpdateTile): Observable<Tile> {
        return this.httpService.putRequest<Tile>(`${this.routePrefix}`, updateTile);
    }

    deleteAllTilesByDashboardId(dashboardId: number) {
        return this.httpService.deleteRequest<number>(`${this.routePrefix}/dashboard/${dashboardId}`);
    }

    getAllTilesByDashboardId(dashboardId: number): Observable<Tile[]> {
        return this.httpService.getRequest<Tile[]>(`${this.routePrefix}/dashboard/${dashboardId}`);
    }

    setDashboardOrderForTiles(dashboardId: number, tiles: TileWithOrder[]): Observable<Tile[]> {
        return this.httpService.postRequest<Tile[]>(`${this.routePrefix}/dashboard/${dashboardId}/setOrder/`, tiles);
    }
}
