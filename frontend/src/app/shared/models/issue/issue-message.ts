import { IssueDetails } from '@shared/models/issue/issue-details';

export interface IssueMessage {
    id?: string,
    issueId?: string,
    occurredOn: Date,
    issueDetails: IssueDetails
}
