import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';
import { TileGranularityType } from '@shared/models/tile/enums/tile-granularity-type';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';

export interface IssuesPerTimeSettings {
    sourceProjects: number[],
    dateRange: TileDateRangeType,
    granularity: TileGranularityType,
    issueStatuses: IssueStatus[],
}
