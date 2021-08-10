import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dashboard } from '@shared/models/dashboard/dashboard';
import { NewDashboard } from '@shared/models/dashboard/new-dashboard';
import { UpdateDashboard } from '@shared/models/dashboard/update-dashboard';
import { HttpInternalService } from './http-internal.service';

@Injectable({ providedIn: 'root' })
export class DashboardService {
    public readonly routePrefix = '/dashboard';

    constructor(private httpService: HttpInternalService) { }

    public getIcons(): string[] {
        return ['pi-chart-bar', 'pi-chart-line'];
    }

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
        return this.httpService.deleteFullRequest<number>(`${this.routePrefix}/${id}`);
    }

    public updateDashboard(updateDashboard: UpdateDashboard): Observable<Dashboard> {
        return this.httpService.putRequest<Dashboard>(`${this.routePrefix}`, updateDashboard);
    }
}
