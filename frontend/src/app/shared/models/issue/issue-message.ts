import { IssueDetails } from '@shared/models/issue/issue-details';
import { Project } from '../projects/project';

export interface IssueMessage {
    id?: string,
    issueId?: number,
    occurredOn: Date,
    issueDetails: IssueDetails,
    project: Project
}
