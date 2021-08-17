import { Assignee } from '@shared/models/assignee/assignee';
import { Member } from '@shared/models/member/member';

export const toImages = (memberIds: number[], members: Member[]): string[] =>
    memberIds.map(id => members.find(m => m.id === id).user.avatarUrl);

export const count = (assignee: Assignee): number => assignee.memberIds.length + assignee.teamIds.length;
