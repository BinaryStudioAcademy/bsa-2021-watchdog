import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileSizeType } from '../enums/tile-size-type';

export interface TopActiveTileSettings {
    sourceProjects: number[],
    dateRange: TileDateRangeType,
    itemsCount: number,
    tileSize: TileSizeType
}
