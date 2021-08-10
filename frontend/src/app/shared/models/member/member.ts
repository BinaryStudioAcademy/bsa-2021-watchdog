import { User } from '@shared/models/user/user';

export interface Member {
    id: number,
    user: User,
    organizationId: number
}
