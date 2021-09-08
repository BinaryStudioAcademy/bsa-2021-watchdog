import { MembersRoleIds } from '@shared/constants/member-roles';
import { Member } from '@shared/models/member/member';

export const hasAccess = (member: Member) => member && (member.roleId !== MembersRoleIds.viewer);
