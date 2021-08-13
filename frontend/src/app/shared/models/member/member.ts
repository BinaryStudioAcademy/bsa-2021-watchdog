import { User } from '@shared/models/user/user';
import { Role } from '../role/role';
import { Team } from '../teams/team';

export interface Member {
    id: number,
    roleId: number,
    teamId: number,
    user: User,
    team: Team,
    role: Role,
    organizationId: number,
    isAccepted: boolean,
}
