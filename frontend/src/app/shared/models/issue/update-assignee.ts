import { Assignee } from './assignee';

export interface UpdateAssignee {
    issueId: number;
    assignee: Assignee;
}
