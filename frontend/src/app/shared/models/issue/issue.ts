import { IssueStatus } from '@shared/models/issue/enums/issue-status';
import { Project } from '@shared/models/projects/project';

export interface Issue {
    id: number,
    errorMessage: string,
    errorClass: string,
    status: IssueStatus,
    project: Project,
}
