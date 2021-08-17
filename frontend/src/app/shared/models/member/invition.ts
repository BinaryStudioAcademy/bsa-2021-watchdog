import { FormGroup } from '@angular/forms';
import { NewMember } from './new-member';

export interface Invition {
    member: NewMember,
    groupForm: FormGroup,
    isInvited?: boolean
}
