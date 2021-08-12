import { Injectable } from '@angular/core';
import { InvitedMember } from '@shared/models/member/invitedMember';
import { Member } from '@shared/models/member/member';
import { NewMember } from '@shared/models/member/new-member';
import { Observable } from 'rxjs';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class MemberService {
    public readonly routePrefix = '/member';

    constructor(private httpService: HttpInternalService) { }

    getMembersByOrganizationId(id: number): Observable<Member[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${id}`);
    }

    searchMembersNotInOrganization(orgId: number, memberEmail: string): Observable<Member[]> {
        const url = `organization/${orgId}/notInOrg/${memberEmail !== '' ? `?memberEmail=${memberEmail}` : ''}`;
        return this.httpService.getRequest<Member[]>(`${this.routePrefix}/${url}`);
    }

    addMemberToOrganization(newMember: NewMember): Observable<InvitedMember> {
        return this.httpService.postRequest(`${this.routePrefix}`, newMember);
    }
}
