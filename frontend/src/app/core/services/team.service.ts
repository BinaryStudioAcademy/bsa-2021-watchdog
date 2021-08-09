import { Injectable } from '@angular/core';
import { HttpInternalService } from '@core/services/http-internal.service';
import { Observable } from 'rxjs';
import { Team } from '@shared/models/teams/team';
import { HttpResponse } from '@angular/common/http';
import { TeamMember } from '@shared/models/teams/team-member';
import { NewTeam } from '@shared/models/teams/new-team';
import { TeamOption } from '@shared/models/teams/team-option';

@Injectable({ providedIn: 'root' })
export class TeamService {
    public readonly routePrefix = '/teams';

    constructor(private httpService: HttpInternalService) { }

    public getTeamOptionsByOrganizationId(organizationId: number): Observable<TeamOption[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}/options`);
    }

    public getTeams(): Observable<HttpResponse<Team[]>> {
        return this.httpService.getFullRequest(`${this.routePrefix}`);
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
