import { User } from '@shared/models/user/user';
import { Role } from '../role/role';
import { TeamOption } from '../teams/team-option';

export interface Member {
    id: number,
    roleId: number,
    user: User,
    teams: TeamOption[],
    role: Role,
    organizationId: number,
    isAccepted: boolean,
    isApproved: boolean
}
