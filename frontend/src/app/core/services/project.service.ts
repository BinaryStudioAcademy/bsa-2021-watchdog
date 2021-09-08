import { Injectable } from '@angular/core';
import { NewProject } from '@shared/models/projects/new-project';
import { Project } from '@shared/models/projects/project';
import { Observable } from 'rxjs';
import { ProjectTeam } from '@shared/models/projects/project-team';
import { NewProjectTeam } from '@shared/models/projects/new-project-team';
import { CoreHttpService } from './core-http.service';
import { UpdateProject } from '@shared/models/projects/update-project';
import { share, tap } from 'rxjs/operators';
import { AppSecrets } from '@shared/models/projects/app-secrets';
import { CountryInfo } from '@shared/models/projects/country-info';
import { RecipientTeam } from '@shared/models/projects/recipient-team';

@Injectable({
    providedIn: 'root',
})
export class ProjectService {
    private apiPrefix = '/applications';

    constructor(
        private httpService: CoreHttpService
    ) { }

    private projRequest$: Observable<Project[]>;
    getProjectsByOrganizationId(id: number): Observable<Project[]> {
        if (this.projRequest$) {
            return this.projRequest$;
        }
        this.projRequest$ = this.httpService.getRequest<Project[]>(`${this.apiPrefix}/organization/${id}`)
            .pipe(
                tap(() => {
                    this.projRequest$ = null;
                }),
                share()
            );
        return this.projRequest$;
    }

    getProjectById(id: number | string): Observable<Project> {
        return this.httpService.getRequest<Project>(`${this.apiPrefix}/${id}`);
    }

    getProjectsByMemberId(id: number): Observable<Project[]> {
        return this.httpService.getRequest<Project[]>(`${this.apiPrefix}/member/${id}`);
    }

    updateProject(id: number | string, updateProject: UpdateProject): Observable<Project> {
        return this.httpService.putRequest<Project>(`${this.apiPrefix}/${id}`, updateProject);
    }

    removeProject(id: number | string) {
        return this.httpService.deleteRequest(`${this.apiPrefix}/${id}`);
    }

    createProject(project: NewProject): Observable<Project> {
        return this.httpService.postRequest(`${this.apiPrefix}`, project);
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
        return this.httpService.putRequest<boolean>(`${this.apiPrefix}/team/${projectTeamId}/favorite/${state}`, {});
    }

    isProjectNameUnique(name: string, organizationId: number): Observable<boolean> {
        return this.httpService.getRequest<boolean>(`${this.apiPrefix}/application/${name}/${organizationId}`);
    }

    getApiKey(): Observable<AppSecrets> {
        return this.httpService.getRequest<AppSecrets>(`${this.apiPrefix}/apiKey`, {});
    }

    isApiKeyUnique(apiKey: string): Observable<boolean> {
        return this.httpService.getRequest<boolean>(`${this.apiPrefix}/apiKey/${apiKey}`);
    }

    getCountriesInfo(projectId: number): Observable<CountryInfo[]> {
        return this.httpService.getRequest<CountryInfo[]>(`${this.apiPrefix}/countriesInfo/${projectId}`);
    }

    getRecipientTeams(projectId: number): Observable<RecipientTeam[]> {
        return this.httpService.getRequest<RecipientTeam[]>(`${this.apiPrefix}/${projectId}/recipients`);
    }
}
