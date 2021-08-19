import { Member } from '../member/member';
import { TeamOption } from '../teams/team-option';

export interface AssigneeOptions {
    members: Member[];
    teams: TeamOption[];
}
