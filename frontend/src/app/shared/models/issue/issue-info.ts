import { Assignee } from './assignee';
import { IssueMessageInfo } from '@shared/models/issue/issue-message-info';
import { Project } from '../projects/project';

export interface IssueInfo {
    issueId: number,
    errorMessage: string,
    errorClass: string,
    eventsCount: number,
    project: Project,
    assignee?: Assignee,
    affected: number,
    newest: IssueMessageInfo
}
