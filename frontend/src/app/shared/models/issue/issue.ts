import { IssueMessage } from '@shared/models/issue/issue-message';

export interface Issue {
    errorMessage: string,
    errorClass: string,
    eventsCount: number,
    events: IssueMessage[],
    newest: Date,
    oldest: Date
}
