import { Injectable } from '@angular/core';
import { InvitedMember } from '@shared/models/member/invitedMember';
import { Member } from '@shared/models/member/member';
import { NewMember } from '@shared/models/member/new-member';
import { Observable } from 'rxjs';
import { CoreHttpService } from './core-http.service';

@Injectable({
    providedIn: 'root'
})
export class MemberService {

    readonly routePrefix = '/members';

    constructor(private httpService: CoreHttpService) { }

    addMemberToOrganization(newMember: NewMember): Observable<InvitedMember> {
        return this.httpService.postRequest(`${this.routePrefix}`, newMember);
    }

    getMembersByOrganizationId(organizationId: number): Observable<Member[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}`);
    }

    searchMembersNotInTeam(teamId: number, memberEmail: string): Observable<Member[]> {
        const url = `team/${teamId}/exceptTeam/${memberEmail !== '' ? `?memberEmail=${memberEmail}` : ''}`;
        return this.httpService.getRequest<Member[]>(`${this.routePrefix}/${url}`);
    }

    getInitials(member: Member) {
        return member.user.firstName.toUpperCase().substr(0, 1) + member.user.lastName.toUpperCase().substr(0, 1);
    }
}
