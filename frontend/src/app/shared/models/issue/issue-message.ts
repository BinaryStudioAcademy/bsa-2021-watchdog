import { IssueDetails } from '@shared/models/issue/issue-details';

export interface IssueMessage {
    occurredOn: Date,
    issueDetails: IssueDetails
}
