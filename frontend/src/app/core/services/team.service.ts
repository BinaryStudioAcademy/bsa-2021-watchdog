import { Injectable } from '@angular/core';
import { CoreHttpService } from './core-http.service';
import { Observable } from 'rxjs';
import { Team } from '@shared/models/teams/team';
import { TeamMember } from '@shared/models/teams/team-member';
import { TeamOption } from '@shared/models/teams/team-option';
import { NewTeam } from '@shared/models/teams/new-team';
import { UpdateTeam } from '@shared/models/teams/update-team';

@Injectable({ providedIn: 'root' })
export class TeamService {
    public readonly routePrefix = '/teams';

    constructor(private httpService: CoreHttpService) { }

    getTeamOptionsByOrganizationId(organizationId: number): Observable<TeamOption[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}/options`);
    }

    getTeam(id: number | string): Observable<Team> {
        return this.httpService.getRequest<Team>(`${this.routePrefix}/${id}`);
    }

    getTeams(id: number): Observable<Team[]> {
        return this.httpService.getRequest<Team[]>(`${this.routePrefix}/organization/${id}`);
    }

    getMemberTeams(organizationId: number, memberId: number): Observable<Team[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}/member/${memberId}`);
    }

    getNotMemberTeams(organizationId: number, memberId: number): Observable<Team[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${organizationId}/notMember/${memberId}`);
    }

    createTeam(newTeam: NewTeam): Observable<Team> {
        return this.httpService.postRequest(`${this.routePrefix}`, newTeam);
    }

    joinTeam(teamId: number, memberId: number): Observable<Team> {
        const teamMember: TeamMember = { teamId, memberId };
        return this.httpService.postRequest(`${this.routePrefix}/joinTeam`, teamMember);
    }

    leaveTeam(teamId: number, memberId: number): Observable<Team> {
        return this.httpService.deleteRequest(`${this.routePrefix}/leaveTeam/${teamId}/member/${memberId}`);
    }

    isNameUnique(teamName: string, orgId: number): Observable<boolean> {
        return this.httpService.getRequest(`${this.routePrefix}/orgId/${orgId}/teamName/${teamName}`);
    }

    updateTeam(id: number, team: UpdateTeam): Observable<Team> {
        return this.httpService.putRequest<Team>(`${this.routePrefix}/${id}`, team);
    }

    removeTeam(id: number) {
        return this.httpService.deleteRequest(`${this.routePrefix}/${id}`);
    }

    getAssigneeTeams(orgId: number): Observable<Team[]> {
        return this.httpService.getRequest<Team[]>(`${this.routePrefix}/organization/${orgId}/assignee`);
    }

    getLabel(teamName: string): string {
        const words = teamName.split(' ');

        let label = words[0].charAt(0);

        if (words.length > 1) {
            label += words[words.length - 1].charAt(0);
        }

        return label.toUpperCase();
    }
}
