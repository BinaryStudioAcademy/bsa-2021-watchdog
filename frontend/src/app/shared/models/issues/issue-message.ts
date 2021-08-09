import { IssueMessageDetails } from '@shared/models/issues/issue-message.details';

export interface IssueMessage {
    occurredOn: Date,
    issueDetails: IssueMessageDetails
}
