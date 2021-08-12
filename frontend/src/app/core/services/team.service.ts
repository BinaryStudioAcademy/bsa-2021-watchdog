import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { Observable } from 'rxjs';
import { Team } from '@shared/models/teams/team';
import { HttpResponse } from '@angular/common/http';
import { TeamMember } from '@shared/models/teams/team-member';
import { TeamOption } from '@shared/models/teams/team-option';
import { NewTeam } from '@shared/models/teams/new-team';
import { UpdateTeam } from '@shared/models/teams/update-team';

@Injectable({ providedIn: 'root' })
export class TeamService {
    public readonly routePrefix = '/teams';

    constructor(private httpService: CoreHttpService) { }

    public getTeamOptionsByOrganizationId(organizationId: number): Observable<TeamOption[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}/options`);
    }

    public getTeam(id: number | string): Observable<Team> {
        return this.httpService.getRequest<Team>(`${this.routePrefix}/${id}`);
    }

    public getTeams(id: number): Observable<Team[]> {
        return this.httpService.getRequest<Team[]>(`${this.routePrefix}/organization/${id}`);
    }

    public getMemberTeams(organizationId: number, memberId: number): Observable<HttpResponse<Team[]>> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}/member/${memberId}`);
    }

    public getNotMemberTeams(organizationId: number, memberId: number): Observable<HttpResponse<Team[]>> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}/notMember/${memberId}`);
    }

    public createTeam(newTeam: NewTeam): Observable<HttpResponse<Team>> {
        return this.httpService.postRequest(`${this.routePrefix}`, newTeam);
    }

    public joinTeam(teamId: number, memberId: number): Observable<HttpResponse<Team>> {
        const teamMember: TeamMember = { teamId, memberId };
        return this.httpService.postRequest(`${this.routePrefix}/joinTeam`, teamMember);
    }

    public leaveTeam(teamId: number, memberId: number): Observable<HttpResponse<Team>> {
        return this.httpService.deleteRequest(`${this.routePrefix}/leaveTeam/${teamId}/member/${memberId}`);
    }

    public isNameUnique(teamName: string): Observable<boolean> {
        return this.httpService.getRequest(`${this.routePrefix}/teamName/${teamName}`);
    }

    public updateTeam(id: number, team: UpdateTeam): Observable<Team> {
        return this.httpService.putRequest<Team>(`${this.routePrefix}/${id}`, team);
    }

    public removeTeam(id: number) {
        return this.httpService.deleteRequest(`${this.routePrefix}/${id}`);
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
