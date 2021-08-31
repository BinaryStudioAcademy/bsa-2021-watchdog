import { IssueStatus } from '@shared/models/issue/enums/issue-status';

export interface IssueStatusesFilter {
    issueStatuses: IssueStatus[],
}
