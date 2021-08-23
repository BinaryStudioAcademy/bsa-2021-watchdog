import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { Observable } from 'rxjs';
import { Tile } from '@shared/models/tile/tile';
import { NewTile } from '@shared/models/tile/new-tile';
import { UpdateTile } from '@shared/models/tile/update-tile';

@Injectable({ providedIn: 'root' })
export class TileService {
    public readonly routePrefix = '/tiles';

    constructor(private httpService: CoreHttpService) {
    }

    public get(id: number): Observable<Tile> {
        return this.httpService.getRequest<Tile>(`${this.routePrefix}/${id}`);
    }

    public addTile(newTile: NewTile): Observable<Tile> {
        return this.httpService.postRequest<Tile>(`${this.routePrefix}`, newTile);
    }

    public deleteTile(tileId: number) {
        return this.httpService.deleteRequest<number>(`${this.routePrefix}/${tileId}`);
    }

    public updateTile(updateTile: UpdateTile): Observable<Tile> {
        return this.httpService.putRequest<Tile>(`${this.routePrefix}`, updateTile);
    }

    public deleteAllTilesByDashboardId(dashboardId: number) {
        return this.httpService.deleteRequest<number>(`${this.routePrefix}/dashboard/${dashboardId}`);
    }

    public getAllTilesByDashboardId(dashboardId: number): Observable<Tile[]> {
        return this.httpService.getRequest<Tile[]>(`${this.routePrefix}/dashboard/${dashboardId}`);
    }
}
