import { IssueStatus } from '@shared/models/issue/enums/issue-status';

export interface IssueStatusesByDateRangeFilter {
    issueStatuses: IssueStatus[],
    dateRange: Date
}
