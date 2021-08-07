import { User } from '@core/models/user';

export interface Member {
    id: number,
    user: User,
    organizationId: number
}
