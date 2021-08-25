import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { CoreHttpService } from './core-http.service';

@Injectable({ providedIn: 'root' })
export class DashboardService {
    public readonly routePrefix = '/dashboard';

    constructor(private httpService: CoreHttpService) { }

    public getAllByOrganization(id: number): Observable<Dashboard[]> {
        return this.httpService.getRequest<Dashboard[]>(`${this.routePrefix}/organization/${id}`);
    }

    public get(id: string): Observable<Dashboard> {
        return this.httpService.getRequest<Dashboard>(`${this.routePrefix}/${id}`);
    }

    public addDashboard(newDashboard: NewDashboard): Observable<Dashboard> {
        return this.httpService.postRequest<Dashboard>(`${this.routePrefix}`, newDashboard);
    }

    public deleteDashboard(id: number) {
        return this.httpService.deleteRequest<number>(`${this.routePrefix}/${id}`);
    }

    public updateDashboard(updateDashboard: UpdateDashboard): Observable<Dashboard> {
        return this.httpService.putRequest<Dashboard>(`${this.routePrefix}`, updateDashboard);
    }

    public isDashboardNameUnique(name: string, organizationId: number): Observable<boolean> {
        return this.httpService.getRequest<boolean>(`${this.routePrefix}/dashboard/${name}/${organizationId}`);
    }
}
