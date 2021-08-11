import { TileCategory } from '@shared/models/tile/enums/tile-category';
import { TileType } from '@shared/models/tile/enums/tile-type';

export interface Tile {
    id: number,
    name: string,
    category: TileCategory,
    type: TileType,
    dashboardId: number,
    createdBy: number,
    createdAt: Date,
    settings: string
}
