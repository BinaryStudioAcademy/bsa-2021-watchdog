import { TileDateRangeType } from '@shared/models/tile/tile-date-range-type';

export interface TopActiveIssuesSettings {
    sourceProjects: number[],
    dateRange: TileDateRangeType,
    issuesCount: number
}
