import { TileDateRangeType } from '@shared/models/tile/enums/tile-date-range-type';

export interface TopActiveIssuesSettings {
    sourceProjects: number[],
    dateRange: TileDateRangeType,
    issuesCount: number
}
