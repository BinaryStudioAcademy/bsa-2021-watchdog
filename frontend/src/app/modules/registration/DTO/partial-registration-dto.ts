import { RegOrganizationDto } from './reg-organization-dto';

export interface PartialRegistrationDto {
    organization: RegOrganizationDto,
    userId: number
}
