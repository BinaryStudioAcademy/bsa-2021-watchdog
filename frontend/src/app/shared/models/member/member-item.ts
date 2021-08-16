import { TreeNode } from 'primeng/api';
import { Role } from '../role/role';
import { Member } from './member';

export interface MemberItem {
    member: Member,
    treeTeams: TreeNode[],
    isEdit?: boolean,
    saveRole?: Role;
}
