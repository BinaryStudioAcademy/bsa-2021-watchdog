import { IssueMessage } from '@shared/models/issue/issue-message';

export interface Issue {
    errorMessage: string,
    errorClass: string,
    eventCount: number,
    events: IssueMessage[],
    newest: Date,
    oldest: Date
}
