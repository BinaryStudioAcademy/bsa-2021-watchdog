import { IssueMessage } from '@shared/models/issue/issue-message';

export interface IssueInfo {
    errorMessage: string,
    errorClass: string,
    eventsCount: number,
    newest: IssueMessage
}
