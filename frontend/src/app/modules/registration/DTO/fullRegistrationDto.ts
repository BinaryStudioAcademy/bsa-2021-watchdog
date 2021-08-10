import { NewUserDto } from "./newUserDto";
import { RegOrganizationDto } from "./regOrganizationDto";

export interface FullRegistrationDto {
    organization: RegOrganizationDto,
    user: NewUserDto
}