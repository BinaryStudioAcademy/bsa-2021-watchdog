import { IssueMessageDetails } from '@shared/models/issues/issue-message.details';
import { Assignee } from '../assignee/assignee';

export interface IssueMessage {
    occurredOn: Date,
    issueDetails: IssueMessageDetails,
    assignee?: Assignee
}
