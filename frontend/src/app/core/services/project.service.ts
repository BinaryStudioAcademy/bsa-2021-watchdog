import { Injectable } from '@angular/core';
import { NewProject } from '@shared/models/projects/new-project';
import { Project } from '@shared/models/projects/project';
import { Observable } from 'rxjs';
import { HttpInternalService } from './http-internal.service';

@Injectable({
    providedIn: 'root'
})
export class ProjectService {
    public readonly routePrefix = '/applications';

    constructor(private httpService: HttpInternalService) { }

    public getProjectsByOrganizationId(id: number): Observable<Project[]> {
        return this.httpService.getRequest(`${this.routePrefix}/organization/${id}`);
    }

    public createProject(project: NewProject): Observable<Project> {
        return this.httpService.postRequest(`${this.routePrefix}`, project);
    }
}
