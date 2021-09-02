import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileType } from '@shared/models/tile/enums/tile-type';

export interface NewTile {
    name: string,
    category: TileCategory,
    type: TileType,
    dashboardId: number,
    tileOrder?: number,
    createdBy: number,
    settings: string
}
