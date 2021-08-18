import { Assignee } from './assignee'
export interface UpdateAssignee {
    issueId: string;
    assignee: Assignee;
}