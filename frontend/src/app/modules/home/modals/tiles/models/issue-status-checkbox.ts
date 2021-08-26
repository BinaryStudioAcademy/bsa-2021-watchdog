import { IssueStatus } from '@shared/models/issue/enums/issue-status';

export interface IssueStatusCheckbox {
    name: string,
    type: IssueStatus
}
