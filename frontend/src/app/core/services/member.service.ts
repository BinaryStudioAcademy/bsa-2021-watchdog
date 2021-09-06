import { Injectable } from '@angular/core';
import { InvitedMember } from '@shared/models/member/invited-member';
import { Member } from '@shared/models/member/member';
import { NewMember } from '@shared/models/member/new-member';
import { LazyLoadEvent } from 'primeng/api';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
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
        return this.httpService.getRequest<Member[]>(`${this.routePrefix}/organization/${organizationId}`);
    }

    getMembersByOrganizationIdLazy(organizationId: number, event: LazyLoadEvent):
    Observable<{ collection: Member[], totalRecord: number }> {
        return this.httpService
            .postRequest<{ collection: Member[], totalRecord: number }>(`${this.routePrefix}/organization/${organizationId}`, event);
    }

    private static member: Member;

    clearMember() {
        MemberService.member = null;
    }

    getCurrentMember(organizationId: number, userId: number): Observable<Member> {
        if (!MemberService.member) {
            return this.getMemberByUserAndOrganization(organizationId, userId)
                .pipe(
                    tap(member => {
                        MemberService.member = member;
                    }),
                    map(() => MemberService.member)
                );
        }
        return of(MemberService.member);
    }

    getMemberByUserAndOrganization(organizationId: number, userId: number): Observable<Member> {
        return this.httpService.getRequest<Member>(`${this.routePrefix}/organization/${organizationId}/user/${userId}`);
    }

    searchMembersNotInTeam(teamId: number, count: number, memberEmail: string): Observable<Member[]> {
        const url = `team/${teamId}/exceptTeam/?count=${count}${memberEmail !== '' ? `&memberEmail=${memberEmail}` : ''}`;
        return this.httpService.getRequest<Member[]>(`${this.routePrefix}/${url}`);
    }

    updateMember(id: number, roleId: number) {
        return this.httpService.putRequest<Member>(`${this.routePrefix}`, { id, roleId });
    }

    deleteMember(id: number) {
        return this.httpService.deleteRequest(`${this.routePrefix}/${id}`);
    }

    reinviteMember(id: number) {
        return this.httpService.postRequest(`${this.routePrefix}/reinvite`, { id });
    }

    approveMember(id: number) {
        return this.httpService.postRequest(`${this.routePrefix}/approveUser`, { id });
    }

    getInitials(member: Member) {
        return member.user.firstName.toUpperCase().substr(0, 1) + member.user.lastName.toUpperCase().substr(0, 1);
    }

    isMemberOwner(memberId: number): Observable<boolean> {
        return this.httpService.getRequest<boolean>(`${this.routePrefix}/isowner/${memberId}`);
    }
}
