import { RegOrganizationDto } from "./regOrganizationDto";

export interface PartialRegistrationDto {
    organization: RegOrganizationDto,
    userId: number
}