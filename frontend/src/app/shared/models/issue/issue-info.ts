import { Assignee } from './assignee';
import { IssueMessageInfo } from '@shared/models/issue/issue-message-info';

export interface IssueInfo {
    issueId: number,
    errorMessage: string,
    errorClass: string,
    eventsCount: number,
    assignee?: Assignee,
    newest: IssueMessageInfo
}
