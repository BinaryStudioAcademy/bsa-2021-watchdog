import { TileCategory } from '@shared/models/tile/tile-category';
import { TileType } from '@shared/models/tile/tile-type';

export interface Tile {
    id: number,
    name: string,
    category: TileCategory,
    type: TileType,
    dashboardId: number,
    createdBy: number,
    settings: string
}
