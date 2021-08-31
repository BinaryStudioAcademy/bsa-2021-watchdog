import { IssueStatus } from './enums/issue-status';

export interface IssueMessageInfo {
    id: string,
    status: IssueStatus,
    occurredOn: Date
}
