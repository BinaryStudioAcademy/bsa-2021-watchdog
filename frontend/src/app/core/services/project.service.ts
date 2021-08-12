import { Injectable } from '@angular/core';
import { NewProject } from '@shared/models/projects/new-project';
import { Project } from '@shared/models/projects/project';
import { Observable } from 'rxjs';
import { ProjectTeam } from '@shared/models/projects/project-team';
import { NewProjectTeam } from '@shared/models/projects/new-project-team';
import { CoreHttpService } from './core-http.service';

@Injectable({
    providedIn: 'root',
})
export class ProjectService {
    private apiPrefix = '/applications';

    constructor(
        private httpService: CoreHttpService
    ) { }

    getProjectsByOrganizationId(id: number): Observable<Project[]> {
        return this.httpService.getRequest(`${this.apiPrefix}/organization/${id}`);
    }

    public createProject(project: NewProject): Observable<Project> {
        return this.httpService.postRequest(`${this.apiPrefix}`, project);
    }

    getProject(id: number): Observable<Project> {
        return this.httpService.getRequest<Project>(`${this.apiPrefix}/${id}`);
    }

    getProjectsByTeam(id: number): Observable<ProjectTeam[]> {
        return this.httpService.getRequest<ProjectTeam[]>(`${this.apiPrefix}/team/${id}`);
    }

    addProjectToTeam(projectId: number, teamId: number) {
        const projectTeam: NewProjectTeam = { projectId, teamId };
        return this.httpService.postRequest<ProjectTeam[]>(`${this.apiPrefix}/team/`, projectTeam);
    }

    updateProjectTeamFavorite(projectTeamId: number, state: boolean) {
        return this.httpService.putRequest<boolean>(`${this.apiPrefix}/team/${projectTeamId}/favorite`, { state });
    }

    removeProjectFromTeam(projectTeamId: number) {
        return this.httpService.deleteRequest<ProjectTeam[]>(`${this.apiPrefix}/team/${projectTeamId}`);
    }

    searchProjectsNotInTeam(teamId: number, projectName: string) {
        const appName = projectName !== '' ? `?appName=${projectName}` : '';
        const url = `team/${teamId}/exceptTeam/${appName}`;
        return this.httpService.getRequest<Project[]>(`${this.apiPrefix}/${url}`);
    }

    setProjectForTeamAsFavorite(projectTeamId: number, state: boolean): Observable<boolean> {
        return this.httpService.putRequest<boolean>(`${this.apiPrefix}/team/${projectTeamId}/favorite/${state}`, { });
    }
}
