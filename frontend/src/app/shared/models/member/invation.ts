import { FormGroup } from "@angular/forms";
import { NewMember } from "./new-member";

export interface Invation {
    member: NewMember,
    groupForm: FormGroup,
    isInvited?: boolean
}