import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Project } from '@shared/models/projects/project';
import { map } from 'rxjs/operators';
import { JsonPatch } from '@shared/models/json-patch';
import { HttpInternalService } from './http-internal.service';
import { ShareDataService } from './share-data.service';
import { HttpResponse } from '@angular/common/http';

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

    getProjectsByTeam(id: number): Observable<Project[]> {
        return this.httpService.getRequest<Project[]>(`${this.apiPrefix}/team/${id}`);
    }

    addProjectToTeam(projectId: number, teamId: number) {

    }

    removeProjectFromTeam(projectId: number, teamId: number) {

    }
}
