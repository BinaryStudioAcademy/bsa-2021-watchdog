import { User } from '../../models/user';

export interface AuthUser {
    user: User;
    token: string;
}
