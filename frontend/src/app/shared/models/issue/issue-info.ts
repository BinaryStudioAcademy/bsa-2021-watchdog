import { IssueMessage } from '@shared/models/issue/issue-message';
import { Assignee } from './assignee';

export interface IssueInfo {
    errorMessage: string,
    errorClass: string,
    eventsCount: number,
    newest: IssueMessage,
    assignee?: Assignee,
}
