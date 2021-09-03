import { Assignee } from './assignee';
import { IssueMessageInfo } from '@shared/models/issue/issue-message-info';
import { Project } from '../projects/project';
import { IssueStatus } from '@shared/models/issue/enums/issue-status';

export interface IssueInfo {
    issueId: number,
    errorMessage: string,
    errorClass: string,
    eventsCount: number,
    affectedUsersCount: number,
    status: IssueStatus,
    project: Project,
    assignee?: Assignee,
    newest: IssueMessageInfo
}
