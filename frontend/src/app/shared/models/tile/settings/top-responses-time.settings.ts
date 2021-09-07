import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileSizeType } from '@shared/models/tile/enums/tile-size-type';

export interface TopResponsesTimeSettings {
    sourceProjects: number[],
    dateRange: TileDateRangeType,
    responsesCount: number,
    tileSize: TileSizeType
}
