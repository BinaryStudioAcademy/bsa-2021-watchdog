import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileSizeType } from '../enums/tile-size-type';

export interface TopActiveIssuesSettings {
    sourceProjects: number[],
    dateRange: TileDateRangeType,
    issuesCount: number,
    tileSize: TileSizeType
}
