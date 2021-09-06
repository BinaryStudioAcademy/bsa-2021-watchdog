import { Assignee } from './assignee';
import { IssueStatus } from './enums/issue-status';

export interface IssueTableItem {
    issueId: number,
    errorMessage: string,
    errorClass: string,
    status: IssueStatus,
    eventsCount: number,
    newestId: string,
    occurredOn: Date,
    projectId: number,
    projectName: string,
    assignee: Assignee,
    affectedUsersCount: number
}
