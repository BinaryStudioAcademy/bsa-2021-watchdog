import { User } from '@shared/models/user/user';
import { RowToggler } from 'primeng/table';
import { Role } from '../role/role';
import { Team } from '../team/team';

export interface Member {
    id: number,
    roleId: number,
    teamId: number,
    user: User,
    team: Team, 
    role: Role,
    organizationId: number
}
