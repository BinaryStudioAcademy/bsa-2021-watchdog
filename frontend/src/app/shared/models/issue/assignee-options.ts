import { Member } from '../member/member';
import { Team } from '../teams/team';

export interface AssigneeOptions {
    members: Member[];
    teams: Team[];
}
