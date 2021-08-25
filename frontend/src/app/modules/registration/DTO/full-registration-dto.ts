import { NewUserDto } from './new-user-dto';
import { RegOrganizationDto } from './reg-organization-dto';

export interface FullRegistrationDto {
    organization: RegOrganizationDto,
    user: NewUserDto
}
