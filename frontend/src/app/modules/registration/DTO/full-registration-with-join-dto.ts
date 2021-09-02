import { NewUserDto } from './new-user-dto';

export interface FullRegistrationWithJoinDto {
    organizationSlug: string,
    user: NewUserDto
}
