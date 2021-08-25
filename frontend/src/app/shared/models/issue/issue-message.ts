import { IssueDetails } from '@shared/models/issue/issue-details';

export interface IssueMessage {
    id?: string,
    issueId?: number,
    occurredOn: Date,
    issueDetails: IssueDetails
}
