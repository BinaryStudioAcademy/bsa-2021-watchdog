import { IssueStatus } from '@shared/models/issue/enums/issue-status';

export interface UpdateIssueStatus {
    issueId: number,
    status: IssueStatus,
}
