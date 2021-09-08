import { IssueAnswer } from './issue-answer';

export interface IssueSolutionItem {
    body: string;
    answers: IssueAnswer[];
}
