import { Assignee } from '@shared/models/issue/assignee';
import { Member } from '@shared/models/member/member';

export const toImages = (memberIds: number[], members: Member[]): string[] =>
    memberIds.map(id => members.find(m => m.id === id).user.avatarUrl);

export const count = (assignee: Assignee): number => assignee.memberIds.length + assignee.teamIds.length;

export const clearNest = (value: string) => {
    switch (value) {
        case 'newest.occurredOn':
            return 'occurredOn';
        default:
            return value;
    }
};

export const clearIssueMessage = (value: string) => {
    switch (value) {
        case 'issueDetails.environmentMessage.platform':
            return 'platform';
        case 'issueDetails.environmentMessage.browser':
            return 'browser';
        default:
            return value;
    }
};
