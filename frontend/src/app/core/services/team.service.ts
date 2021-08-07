import { Injectable } from '@angular/core';
import { HttpInternalService } from '@core/services/http-internal.service';
import { Observable } from "rxjs";
import { Team } from '@shared/models/team/team';
import { HttpResponse } from '@angular/common/http';
import { TeamMember } from '@shared/models/team/team-member';
import { NewTeam } from '@shared/models/team/new-team';

@Injectable({ providedIn: 'root' })
export class TeamService {
    public readonly routePrefix = '/teams';

    constructor(private httpService: HttpInternalService) { }

    public getTeam(id: number): Observable<Team> {
        return this.httpService.getRequest<Team>(`${this.routePrefix}/${id}`);
    }

    public getTeams(id: number): Observable<Team[]> {
        return this.httpService.getRequest<Team[]>(`${this.routePrefix}/organization/${id}`);
    }

    public getMemberTeams(organizationId: number, memberId: number): Observable<HttpResponse<Team[]>> {
        return this.httpService.getFullRequest(`${this.routePrefix}/organization/${organizationId}/member/${memberId}`);
    }

    public getNotMemberTeams(organizationId: number, memberId: number): Observable<HttpResponse<Team[]>> {
        return this.httpService.getFullRequest(`${this.routePrefix}/organization/${organizationId}/notMember/${memberId}`);
    }

    public createTeam(newTeam: NewTeam): Observable<HttpResponse<Team>> {
        return this.httpService.postFullRequest(`${this.routePrefix}`, newTeam);
    }

    public joinTeam(teamMember: TeamMember): Observable<HttpResponse<Team>> {
        return this.httpService.postFullRequest(`${this.routePrefix}/joinTeam`, teamMember);
    }

    public leaveTeam(teamId: number, memberId: number): Observable<HttpResponse<Team>> {
        return this.httpService.deleteFullRequest(`${this.routePrefix}/leaveTeam/${teamId}/member/${memberId}`);
    }

    public getLabel(teamName: string): string {
        const words = teamName.split(' ');

        let label = words[0].charAt(0);

        if (words.length > 1) {
            label += words[words.length - 1].charAt(0);
        }

        return label.toUpperCase();
    }
}
