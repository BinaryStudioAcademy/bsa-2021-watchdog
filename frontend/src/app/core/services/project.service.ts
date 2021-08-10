import { ProjectTeam } from "./../../shared/models/projects/project-team";
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { HttpInternalService } from './http-internal.service';
import { NewProjectTeam } from "@shared/models/projects/new-project-team";

@Injectable({
    providedIn: 'root',
})
export class ProjectService {
    private apiPrefix = '/applications';

    constructor(
        private httpService: HttpInternalService
    ) { }

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
        const url = `team/${teamId}/exceptTeam/${projectName !== '' ? '?appName=' + projectName : ''}`;
        return this.httpService.getRequest<Project[]>(`${this.apiPrefix}/${url}`);
    }
}
